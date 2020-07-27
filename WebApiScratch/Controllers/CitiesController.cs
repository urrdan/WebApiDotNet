using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiScratch.Contexts;

namespace WebApiScratch.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly CityInfoContext _ctx;
        public CitiesController(CityInfoContext ctx ) { _ctx = ctx; }
        
        [HttpGet]
        
        public IActionResult GetCities() {
            return Ok( CitiesStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id) {
            var city = CitiesStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (city==null) {
                return NotFound();
            }
            return Ok(city);
        }

    }
}
