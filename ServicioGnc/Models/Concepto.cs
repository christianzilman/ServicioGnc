using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Concepto
    {
        public Concepto()
        {
            this.DetalleLiquidacions = new List<DetalleLiquidacion>();
        }

        public int ConceptoId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        public Nullable<double> Porcentaje { get; set; }
        public Nullable<double> Importe { get; set; }
        public Nullable<int> Utilidad { get; set; }
        public Nullable<int> TipoConceptoId { get; set; }
        public virtual TipoConcepto TipoConcepto { get; set; }
        public virtual ICollection<DetalleLiquidacion> DetalleLiquidacions { get; set; }
    }
}
