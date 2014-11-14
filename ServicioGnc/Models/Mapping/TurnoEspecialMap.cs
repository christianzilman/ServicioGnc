using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class TurnoEspecialMap : EntityTypeConfiguration<TurnoEspecial>
    {
        public TurnoEspecialMap()
        {
            // Primary Key
            this.HasKey(t => t.TurnoEspecialId);

            // Properties
            // Table & Column Mappings
            this.ToTable("TurnoEspecial");
            this.Property(t => t.TurnoEspecialId).HasColumnName("TurnoEspecialId");
            this.Property(t => t.FeriadoId).HasColumnName("FeriadoId");
            this.Property(t => t.PersonaId).HasColumnName("PersonaId");

            // Relationships
            this.HasOptional(t => t.Feriado)
                .WithMany(t => t.TurnoEspecials)
                .HasForeignKey(d => d.FeriadoId);
            this.HasOptional(t => t.Persona)
                .WithMany(t => t.TurnoEspecials)
                .HasForeignKey(d => d.PersonaId);

        }
    }
}
