using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class DetalleTurnoMap : EntityTypeConfiguration<DetalleTurno>
    {
        public DetalleTurnoMap()
        {
            // Primary Key
            this.HasKey(t => t.DetalleTurnoId);

            // Properties
            this.Property(t => t.Dia)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("DetalleTurno");
            this.Property(t => t.DetalleTurnoId).HasColumnName("DetalleTurnoId");
            this.Property(t => t.HorarioId).HasColumnName("HorarioId");
            this.Property(t => t.Dia).HasColumnName("Dia");
            this.Property(t => t.TurnoId).HasColumnName("TurnoId");

            // Relationships
            this.HasOptional(t => t.Horario)
                .WithMany(t => t.DetalleTurnoes)
                .HasForeignKey(d => d.HorarioId);
            this.HasOptional(t => t.Turno)
                .WithMany(t => t.DetalleTurnoes)
                .HasForeignKey(d => d.TurnoId);

        }
    }
}
