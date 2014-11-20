using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class LecturaPresionTemperatura
    {
        public int LecturaPresionTemperaturaId { get; set; }
        public string Nombre { get; set; }
        public Nullable<double> Presion { get; set; }
        public Nullable<double> Temperatura { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}
