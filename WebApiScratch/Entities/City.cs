using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiScratch.Entities
{
    public class City

    {
        [Key]
        //notation is not really in this case necessary since convention automatically 
        //sets the primary key to any field named "Id" or classname plus id i.e "CityId"
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //this is for id generation when new city is added but can be handled automatically.
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Detail { get; set; }
        public ICollection<PointOfInterest> PointOfInterest { get; set; } = new List<PointOfInterest>();
    }
}