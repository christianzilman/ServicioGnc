using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Rol
    {
        public Rol()
        {
            this.Personas = new List<Persona>();
        }

        public int RolId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
