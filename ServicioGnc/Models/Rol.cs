using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Rol
    {
        public Rol()
        {
            this.Personas = new List<Persona>();
        }

        public int RolId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
