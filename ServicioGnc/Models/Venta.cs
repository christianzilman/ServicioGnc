using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Venta
    {
        public Venta()
        {
            this.DetalleVentas = new List<DetalleVenta>();
        }

        public int VentaId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
    }
}
