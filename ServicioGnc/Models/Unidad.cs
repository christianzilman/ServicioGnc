using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            this.Productoes = new List<Producto>();
        }

        public int UnidadId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
