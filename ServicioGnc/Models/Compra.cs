using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<int> TipoEstadoId { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
