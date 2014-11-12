using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            this.Ventas = new List<Venta>();
        }

        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el domicilio")]
        public string Domicilio { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
