using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            this.Productoes = new List<Producto>();
        }

        public int UnidadId { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { get; set; }
        public virtual ICollection<Producto> Productoes { get; set; }
    }
}
