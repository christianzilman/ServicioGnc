using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicioGnc.Models
{
    public partial class Persona
    {
        public Persona()
        {
            this.AsignacionTurnoes = new List<AsignacionTurno>();
            this.Familiars = new List<Familiar>();
            this.Fichadas = new List<Fichada>();
            this.Liquidacions = new List<Liquidacion>();
            this.TurnoEspecials = new List<TurnoEspecial>();
        }

        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> RolId { get; set; }
        public string Apellido { get; set; }
        public string Domicilio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaEgreso { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<int> Dni { get; set; }
        public virtual ICollection<AsignacionTurno> AsignacionTurnoes { get; set; }
        public virtual ICollection<Familiar> Familiars { get; set; }
        public virtual ICollection<Fichada> Fichadas { get; set; }
        public virtual ICollection<Liquidacion> Liquidacions { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<TurnoEspecial> TurnoEspecials { get; set; }
    }
}
