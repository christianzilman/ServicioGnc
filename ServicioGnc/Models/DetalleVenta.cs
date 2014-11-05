using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public Nullable<int> ProductoId { get; set; }
        public Nullable<int> VentaId { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<double> Subtotal { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
