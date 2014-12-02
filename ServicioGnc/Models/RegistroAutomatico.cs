using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class RegistroAutomatico
    {
        public int RegistroAutomaticoId { get; set; }
        public Nullable<int> TurnoEspecialId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public virtual TurnoEspecial TurnoEspecial { get; set; }
    }
}
