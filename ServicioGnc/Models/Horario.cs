using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Horario
    {
        public Horario()
        {
            this.DetalleTurnoes = new List<DetalleTurno>();
        }

        public int HorarioId { get; set; }
        public string ComienzoTurno { get; set; }
        public string FinalTurno { get; set; }
        public virtual ICollection<DetalleTurno> DetalleTurnoes { get; set; }
    }
}
