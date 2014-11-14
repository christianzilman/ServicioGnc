using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Liquidacion
    {
        public Liquidacion()
        {
            this.DetalleLiquidacions = new List<DetalleLiquidacion>();
        }

        public int LiquidacionId { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public Nullable<double> Total { get; set; }
        public string Periodo { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public virtual ICollection<DetalleLiquidacion> DetalleLiquidacions { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
