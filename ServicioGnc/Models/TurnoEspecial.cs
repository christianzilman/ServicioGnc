using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class TurnoEspecial
    {
        public int TurnoEspecialId { get; set; }
        public Nullable<int> FeriadoId { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public virtual Feriado Feriado { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
