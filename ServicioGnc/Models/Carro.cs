using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Carro
    {
        public int CarroId { get; set; }
        public Nullable<int> UsuarioId { get; set; }
        public Nullable<int> ProductoId { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<double> SubTotal { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<int> TipoOperacionId { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
