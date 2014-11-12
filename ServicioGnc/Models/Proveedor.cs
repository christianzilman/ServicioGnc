using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            this.Compras = new List<Compra>();
        }

        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la raz�n social")]
        public string RazonSocial { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el CUIT")]
        [RegularExpression(@"\d{2}-\d{7}-\d",
            ErrorMessage = "CUIT INV�LIDO")]
        public string CUIT { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Domicilio")]
        public string Domicilio { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
