using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiScratch.Modals;

namespace WebApiScratch.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointofinterest")]
    public class PointOfInterestController :ControllerBase
    {
        [HttpGet]
        public IActionResult GetPointsOfInterest(int cityId) 
        {
            var city = CitiesStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) 
            { 
                return NotFound(); 
            }
            return Ok(city.PointOfInterest);
        }


        [HttpGet("{id}", Name="GetPointOfInterest")]
        public IActionResult GetSinglePointOfInterest(int cityId, int id) {

            var city = CitiesStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null){ return NotFound();}

            var pointOfInterest = city.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if (pointOfInterest == null) { return NotFound(); }

            return Ok(pointOfInterest);
        }


        [HttpPost]
        public IActionResult poster(int cityId, [FromBody] PointOfInterestCreationDto newPointOfInterest) {

            var city = CitiesStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            if (newPointOfInterest.Comment==newPointOfInterest.Name) {
                ModelState.AddModelError("comment", "comment should not be same as name");
            }

            if (!ModelState.IsValid) { return BadRequest(ModelState);} //for data anotation.
            //can be automatically handle by apiConroller, but its required if custom Modelerror are added. 

            var maxId = CitiesStore.Current.Cities.SelectMany(c => c.PointOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxId,
                Name = newPointOfInterest.Name,
                Comment = newPointOfInterest.Comment
            };

            city.PointOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new { cityId=cityId, id=finalPointOfInterest.Id},
                finalPointOfInterest);
        }


        [HttpPatch("{id}")]
        public IActionResult patcher(int cityId, int id, [FromBody] JsonPatchDocument<PointOfInterestUpdateDto> updatedPointOfInterest) { 
            var city= CitiesStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) { return NotFound(); }
            var pointInterestFromStore= city.PointOfInterest.FirstOrDefault(c => c.Id == id);           
            if (pointInterestFromStore == null) { return NotFound(); }

            var pointOfInterestToPatch = new PointOfInterestUpdateDto()
            {
                Name = pointInterestFromStore.Name,
                Comment = pointInterestFromStore.Comment
            };

            updatedPointOfInterest.ApplyTo(pointOfInterestToPatch, ModelState);
            // modelstate validates the json i.e if its properties match that of the dto. 
            //however it doesn't handle data anotation since its json to do that, validate after
            //it has been applied to by the dto object.

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            if (!TryValidateModel(pointOfInterestToPatch)) { return BadRequest(ModelState); }
            //to validate data anotation

            pointInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointInterestFromStore.Comment = pointOfInterestToPatch.Comment;

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult deleteResource(int cityId, int id) {

            var city = CitiesStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null) { return NotFound(); }

            var pointInterestFromStore = city.PointOfInterest.FirstOrDefault(c => c.Id == id);
            if (pointInterestFromStore == null) { return NotFound(); }

            city.PointOfInterest.Remove(pointInterestFromStore);

            return NoContent();
        }
    }
}
