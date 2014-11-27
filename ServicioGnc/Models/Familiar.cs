using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Familiar
    {
        public int FamiliarId { get; set; }
        public Nullable<int> PersonaId { get; set; }
         [Required(ErrorMessage = "Debe Ingresar el DNI")]
        public Nullable<int> Dni { get; set; }
         [Required(ErrorMessage = "Debe Ingresar el nombre")]
        public string Nombre { get; set; }
         [Required(ErrorMessage = "Debe Ingresar la relacion con el empleado")]
        public string Relacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
