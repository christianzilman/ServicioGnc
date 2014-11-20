using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Venta
    {
        public Venta()
        {
            this.DetalleVentas = new List<DetalleVenta>();
        }

        public int VentaId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public Nullable<int> TipoEstadoId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }
        public virtual TipoEstado TipoEstado { get; set; }
    }
}
