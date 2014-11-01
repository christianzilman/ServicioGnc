using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class DetalleTurno
    {
        public int DetalleTurnoId { get; set; }
        public Nullable<int> HorarioId { get; set; }
        public string Dia { get; set; }
        public Nullable<int> TurnoId { get; set; }
        public virtual Horario Horario { get; set; }
        public virtual Turno Turno { get; set; }
    }
}
