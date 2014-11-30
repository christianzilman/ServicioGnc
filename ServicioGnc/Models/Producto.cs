using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Producto
    {
        public Producto()
        {
            this.Carroes = new List<Carro>();
            this.DetalleCompras = new List<DetalleCompra>();
            this.DetalleVentas = new List<DetalleVenta>();
        }

        public int ProductoId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Precio inválido. Debe tener 2 decimales como máximo")]
        public Nullable<double> PrecioCompra { get; set; }
        public Nullable<int> UnidadId { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Precio inválido. Debe tener 2 decimales como máximo")]
        public Nullable<double> PrecioVenta { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public virtual ICollection<Carro> Carroes { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public virtual Unidad Unidad { get; set; }
    }
}
