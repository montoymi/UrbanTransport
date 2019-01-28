using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanTransport.Models
{
    public class Route
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 20 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public virtual ICollection<BusRoute> BusRoutes { get; set; }
        public virtual ICollection<CheckPoint> CheckPoints { get; set; }
    }
}
