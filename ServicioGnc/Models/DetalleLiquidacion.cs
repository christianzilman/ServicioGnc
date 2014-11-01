using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class DetalleLiquidacion
    {
        public int DetalleLiquidacionId { get; set; }
        public Nullable<int> LiquidacionId { get; set; }
        public Nullable<int> ConceptoId { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public virtual Concepto Concepto { get; set; }
        public virtual Liquidacion Liquidacion { get; set; }
    }
}
