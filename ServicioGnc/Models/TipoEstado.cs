using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class TipoEstado
    {
        public TipoEstado()
        {
            this.Ventas = new List<Venta>();
        }

        public int TipoEstadoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
