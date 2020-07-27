using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiScratch.Modals
{
    public class PointOfInterestCreationDto
    {
        [Required(ErrorMessage ="You should provide a name value")] //custom error message
        [MaxLength(50,ErrorMessage ="name should be at most 50 characters")]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }
    }
}
