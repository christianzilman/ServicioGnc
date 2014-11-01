using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Fichada
    {
        public int FichadaId { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaEgreso { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public string Observacion { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
