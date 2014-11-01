using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            this.Compras = new List<Compra>();
        }

        public int ProveedorId { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Domicilio { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
