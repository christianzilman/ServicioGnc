using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class TipoEstadoMap : EntityTypeConfiguration<TipoEstado>
    {
        public TipoEstadoMap()
        {
            // Primary Key
            this.HasKey(t => t.TipoEstadoId);

            // Properties
            this.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TipoEstado");
            this.Property(t => t.TipoEstadoId).HasColumnName("TipoEstadoId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
