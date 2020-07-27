using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiScratch.Modals
{
    public class PointOfInterestUpdateDto
    {
        [MaxLength(50, ErrorMessage = "name should be at most 50 characters")]
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
