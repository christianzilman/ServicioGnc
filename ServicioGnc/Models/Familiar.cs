using System;
using System.Collections.Generic;

namespace ServicioGnc.Models
{
    public partial class Familiar
    {
        public int FamiliarId { get; set; }
        public Nullable<int> PersonaId { get; set; }
        public Nullable<int> Dni { get; set; }
        public string Nombre { get; set; }
        public string Relacion { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
