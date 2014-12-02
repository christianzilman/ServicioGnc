using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Feriado
    {
        public Feriado()
        {
            this.TurnoEspecials = new List<TurnoEspecial>();
        }

        public int FeriadoId { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<TurnoEspecial> TurnoEspecials { get; set; }
    }
}
