using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Persona
    {
        public Persona()
        {
            this.AsignacionTurnoes = new List<AsignacionTurno>();
            this.Fichadas = new List<Fichada>();
            this.Liquidacions = new List<Liquidacion>();
        }

        public int PersonaId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        public Nullable<int> RolId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Domicilio")]
        public string Domicilio { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<System.DateTime> FechaEgreso { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public virtual ICollection<AsignacionTurno> AsignacionTurnoes { get; set; }
        public virtual ICollection<Fichada> Fichadas { get; set; }
        public virtual ICollection<Liquidacion> Liquidacions { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
