using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class TipoConcepto
    {
        public TipoConcepto()
        {
            this.Conceptoes = new List<Concepto>();
        }

        public int TipoConceptoId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { get; set; }
        public virtual ICollection<Concepto> Conceptoes { get; set; }
    }
}
