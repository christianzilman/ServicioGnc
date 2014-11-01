using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Producto
    {
        public Producto()
        {
            this.DetalleCompras = new List<DetalleCompra>();
            this.DetalleVentas = new List<DetalleVenta>();
        }

        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> PrecioCompra { get; set; }
        public Nullable<int> UnidadId { get; set; }
        public Nullable<double> PrecioVenta { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public virtual Unidad Unidad { get; set; }
    }
}
