using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ServicioGnc.Models
{
    public partial class Familiar
    {
        public int FamiliarId { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public Nullable<int> Dni { get; set; }
        public string Nombre { get; set; }
        public string Relacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
