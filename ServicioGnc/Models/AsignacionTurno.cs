using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class AsignacionTurno
    {
        public int AsignacionTurnoId { get; set; }
        public Nullable<int> TurnoId { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public string Observacion { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> Periodo { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
