using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiScratch.Modals
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int NumberOfInterests { get { return PointOfInterest.Count; } }
        public ICollection<PointOfInterestDto> PointOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
