using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class DetalleCompra
    {
        public int DetalleCompraId { get; set; }
        public Nullable<int> ProductoId { get; set; }
        public Nullable<int> CompraId { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<double> Subtotal { get; set; }
        public string Cantidad { get; set; }
        public virtual Compra Compra { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
