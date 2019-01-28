using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanTransport.Models
{
    public class ControlRecord
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Punto de control")]
        public int CheckPointId { get; set; }

        [Required]
        [Display(Name = "Bus")]
        public int BusId { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Fecha de registro")]
        public DateTime RecorDate { get; set; }

        [Display(Name = "Punto de control")]
        public virtual CheckPoint CheckPoint { get; set; }
        [Display(Name = "Bus")]
        public virtual Bus Bus { get; set; }
        [Display(Name = "Usuario")]
        public virtual User User { get; set; }
    }
}
