using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class LecturaPresionTemperatura
    {
        public int LecturaPresionTemperaturaId { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> Presion { get; set; }
        public Nullable<double> Temperatura { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}
