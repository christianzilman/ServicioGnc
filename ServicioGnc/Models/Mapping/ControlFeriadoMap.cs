using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class ControlFeriadoMap : EntityTypeConfiguration<ControlFeriado>
    {
        public ControlFeriadoMap()
        {
            // Primary Key
            this.HasKey(t => t.ControlFeriadoId);

            // Properties
            // Table & Column Mappings
            this.ToTable("ControlFeriado");
            this.Property(t => t.ControlFeriadoId).HasColumnName("ControlFeriadoId");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.PersonaId).HasColumnName("PersonaId");
            this.Property(t => t.DetalleTurnoId).HasColumnName("DetalleTurnoId");

        }
    }
}
