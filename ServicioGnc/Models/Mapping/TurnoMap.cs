using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class TurnoMap : EntityTypeConfiguration<Turno>
    {
        public TurnoMap()
        {
            // Primary Key
            this.HasKey(t => t.TurnoId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Turno");
            this.Property(t => t.TurnoId).HasColumnName("TurnoId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
