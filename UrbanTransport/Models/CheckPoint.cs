using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanTransport.Models
{
    public class CheckPoint
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ruta")]
        public int RouteId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 20 caracteres")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        /*[Required]
        [StringLength(10, ErrorMessage = "La latitud debe tener como máximo 10 caracteres")]
        [Display(Name = "Latitud")]
        public string Latitude { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "La longitud debe tener como máximo 10 caracteres")]
        [Display(Name = "Logitud")]
        public string Longitude { get; set; }*/

        [Display(Name = "Ruta")]
        public virtual Route Route { get; set; }
        public virtual ICollection<ControlRecord> ControlRecords { get; set; }
    }
}
