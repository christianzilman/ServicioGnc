using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class TipoConcepto
    {
        public TipoConcepto()
        {
            this.Conceptoes = new List<Concepto>();
        }

        public int TipoConceptoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Concepto> Conceptoes { get; set; }
    }
}
