using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class ProveedorMap : EntityTypeConfiguration<Proveedor>
    {
        public ProveedorMap()
        {
            // Primary Key
            this.HasKey(t => t.ProveedorId);

            // Properties
            this.Property(t => t.RazonSocial)
                .HasMaxLength(85);

            this.Property(t => t.CUIT)
                .HasMaxLength(13);

            this.Property(t => t.Domicilio)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Proveedor");
            this.Property(t => t.ProveedorId).HasColumnName("ProveedorId");
            this.Property(t => t.RazonSocial).HasColumnName("RazonSocial");
            this.Property(t => t.CUIT).HasColumnName("CUIT");
            this.Property(t => t.Domicilio).HasColumnName("Domicilio");
        }
    }
}
