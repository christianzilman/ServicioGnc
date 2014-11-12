using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            this.Liquidacions = new List<Liquidacion>();
        }

        public int EmpresaId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el CUIT")]
        [RegularExpression(@"\d{2}-\d{7}-\d",
            ErrorMessage = "CUIT INVÁLIDO")]
        public string Cuit { get; set; }
        public virtual ICollection<Liquidacion> Liquidacions { get; set; }
    }
}
