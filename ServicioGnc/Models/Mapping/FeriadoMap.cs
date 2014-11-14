using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class FeriadoMap : EntityTypeConfiguration<Feriado>
    {
        public FeriadoMap()
        {
            // Primary Key
            this.HasKey(t => t.FeriadoId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Feriado");
            this.Property(t => t.FeriadoId).HasColumnName("FeriadoId");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
