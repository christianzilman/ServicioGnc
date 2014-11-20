using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class ControlFeriado
    {
        public int ControlFeriadoId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public Nullable<int> DetalleTurnoId { get; set; }
        public virtual DetalleTurno DetalleTurno { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
