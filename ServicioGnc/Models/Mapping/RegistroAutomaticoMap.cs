using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class RegistroAutomaticoMap : EntityTypeConfiguration<RegistroAutomatico>
    {
        public RegistroAutomaticoMap()
        {
            // Primary Key
            this.HasKey(t => t.RegistroAutomaticoId);

            // Properties
            // Table & Column Mappings
            this.ToTable("RegistroAutomatico");
            this.Property(t => t.RegistroAutomaticoId).HasColumnName("RegistroAutomaticoId");
            this.Property(t => t.TurnoEspecialId).HasColumnName("TurnoEspecialId");
            this.Property(t => t.Fecha).HasColumnName("Fecha");

            // Relationships
            this.HasOptional(t => t.TurnoEspecial)
                .WithMany(t => t.RegistroAutomaticoes)
                .HasForeignKey(d => d.TurnoEspecialId);

        }
    }
}
