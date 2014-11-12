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
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        public Nullable<double> PrecioCompra { get; set; }
        public Nullable<int> UnidadId { get; set; }
        public Nullable<double> PrecioVenta { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public virtual ICollection<Carro> Carroes { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public virtual Unidad Unidad { get; set; }
    }
}
