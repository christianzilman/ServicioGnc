using System;
using System.Collections.Generic;

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
        public string Nombre { get; set; }
        public Nullable<int> RolId { get; set; }
        public string Apellido { get; set; }
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
