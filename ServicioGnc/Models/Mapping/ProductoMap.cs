using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class ProductoMap : EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductoId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(80);

            // Table & Column Mappings
            this.ToTable("Producto");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.PrecioCompra).HasColumnName("PrecioCompra");
            this.Property(t => t.UnidadId).HasColumnName("UnidadId");
            this.Property(t => t.PrecioVenta).HasColumnName("PrecioVenta");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");

            // Relationships
            this.HasOptional(t => t.Unidad)
                .WithMany(t => t.Productoes)
                .HasForeignKey(d => d.UnidadId);

        }
    }
}
