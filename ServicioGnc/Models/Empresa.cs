using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            this.Liquidacions = new List<Liquidacion>();
        }

        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public virtual ICollection<Liquidacion> Liquidacions { get; set; }
    }
}
