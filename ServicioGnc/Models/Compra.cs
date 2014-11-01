using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Compra
    {
        public Compra()
        {
            this.DetalleCompras = new List<DetalleCompra>();
        }

        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> Total { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
