using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class HorarioMap : EntityTypeConfiguration<Horario>
    {
        public HorarioMap()
        {
            // Primary Key
            this.HasKey(t => t.HorarioId);

            // Properties
            this.Property(t => t.ComienzoTurno)
                .HasMaxLength(50);

            this.Property(t => t.FinalTurno)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Horario");
            this.Property(t => t.HorarioId).HasColumnName("HorarioId");
            this.Property(t => t.ComienzoTurno).HasColumnName("ComienzoTurno");
            this.Property(t => t.FinalTurno).HasColumnName("FinalTurno");
        }
    }
}
