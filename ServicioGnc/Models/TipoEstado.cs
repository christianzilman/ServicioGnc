using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class TipoEstado
    {
        public TipoEstado()
        {
            this.Compras = new List<Compra>();
        }

        public int TipoEstadoId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
