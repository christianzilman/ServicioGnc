using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class AsignacionTurnoMap : EntityTypeConfiguration<AsignacionTurno>
    {
        public AsignacionTurnoMap()
        {
            // Primary Key
            this.HasKey(t => t.AsignacionTurnoId);

            // Properties
            this.Property(t => t.Observacion)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("AsignacionTurno");
            this.Property(t => t.AsignacionTurnoId).HasColumnName("AsignacionTurnoId");
            this.Property(t => t.TurnoId).HasColumnName("TurnoId");
            this.Property(t => t.PersonaId).HasColumnName("PersonaId");
            this.Property(t => t.Observacion).HasColumnName("Observacion");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Periodo).HasColumnName("Periodo");

            // Relationships
            this.HasOptional(t => t.Persona)
                .WithMany(t => t.AsignacionTurnoes)
                .HasForeignKey(d => d.PersonaId);
            this.HasOptional(t => t.Turno)
                .WithMany(t => t.AsignacionTurnoes)
                .HasForeignKey(d => d.TurnoId);

        }
    }
}
