using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class UnidadMap : EntityTypeConfiguration<Unidad>
    {
        public UnidadMap()
        {
            // Primary Key
            this.HasKey(t => t.UnidadId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Unidad");
            this.Property(t => t.UnidadId).HasColumnName("UnidadId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
        }
    }
}
