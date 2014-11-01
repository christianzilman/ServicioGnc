using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            this.Ventas = new List<Venta>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
