using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Feriado
    {
        public Feriado()
        {
            this.TurnoEspecials = new List<TurnoEspecial>();
        }

        public int FeriadoId { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { get; set; }
        public virtual ICollection<TurnoEspecial> TurnoEspecials { get; set; }
    }
}
