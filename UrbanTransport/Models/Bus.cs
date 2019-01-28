using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanTransport.Models
{
    public class Bus
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "La licencia de conducir debe tener 10 caracteres")]
        [Display(Name = "Licencia de conducir")]
        public string LicencePlate { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<BusRoute> BusRoutes { get; set; }
        public virtual ICollection<ControlRecord> ControlRecords { get; set; }
    }
}
