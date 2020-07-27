using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiScratch.Entities
{
    public class PointOfInterest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("CityId")]
        //this is not necessary if the foregn key is conventionally named i.e the name of 
        // the class plus id (CityId)
        public City City { get; set; }
        // by convention this property automatically creates a relation between PointOfIntest and
        // City entities since it is non-scalar(which will be considered navigation property)
        public int CityId { get; set; }
        // this foreign key is not necessary since sice the relation was created convetionally 
        //by navigation property and will automatically target the its primaary as foreign key

        [MaxLength(200)]
        public string Comment { get; set; }
    }
}
