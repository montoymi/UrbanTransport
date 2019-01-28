using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrbanTransport.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 15 caracteres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "El apellido debe tener entre 3 y 15 caracteres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "El usuario debe tener entre 3 y 15 caracteres")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 15 caracteres")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Bus")]
        public int BusId { get; set; }


        [Display(Name = "Rol")]
        public virtual Role Role { get; set; }
        [Display(Name = "Bus")]
        public virtual Bus Bus { get; set; }
        public virtual ICollection<ControlRecord> ControlRecords { get; set; }
    }
}
