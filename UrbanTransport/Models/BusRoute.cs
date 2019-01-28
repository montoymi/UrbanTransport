using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanTransport.Models
{
    public class BusRoute
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Bus")]
        public int BusId { get; set; }

        [Required]
        [Display(Name = "Ruta")]
        public int RouteId { get; set; }

        [Display(Name = "Bus")]
        public virtual Bus Bus { get; set; }
        [Display(Name = "Ruta")]
        public virtual Route Route { get; set; }
    }
}
