using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiScratch.Modals;

namespace WebApiScratch
{
    public class CitiesStore
    {
        public static CitiesStore Current { get; } = new CitiesStore();
        public List<CityDto> Cities { get; set; }
        public CitiesStore()
        {
            Cities = new List<CityDto> {
                new CityDto{
                    Id= 1, 
                    Name="Nairobi", 
                    Detail="Busy City especially during rush hours.",
                    PointOfInterest=new List<PointOfInterestDto>{ 
                        new PointOfInterestDto { Id=1, Name="Maasai Mara", Comment="Very enjoyable place"}, 
                        new PointOfInterestDto { Id = 2, Name = "Bomas of Kenya", Comment="A bit too serious" } 
                    } 
                },
                new CityDto{ 
                    Id= 2, 
                    Name="New York", 
                    Detail="Has a big park within the city center",
                    PointOfInterest=new List<PointOfInterestDto>{ 
                        new PointOfInterestDto { Id=3, Name="Nation Assembly", Comment="Ohh! Politicos!"}, 
                        new PointOfInterestDto { Id = 4, Name = "Oama park", Comment="Dinosaures leave here." } 
                    }
                }
            };
        }
    }
}
