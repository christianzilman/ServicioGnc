using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Turno
    {
        public Turno()
        {
            this.AsignacionTurnoes = new List<AsignacionTurno>();
            this.DetalleTurnoes = new List<DetalleTurno>();
        }

        public int TurnoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<AsignacionTurno> AsignacionTurnoes { get; set; }
        public virtual ICollection<DetalleTurno> DetalleTurnoes { get; set; }
    }
}
