using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class DetalleCompraMap : EntityTypeConfiguration<DetalleCompra>
    {
        public DetalleCompraMap()
        {
            // Primary Key
            this.HasKey(t => t.DetalleCompraId);

            // Properties
            // Table & Column Mappings
            this.ToTable("DetalleCompra");
            this.Property(t => t.DetalleCompraId).HasColumnName("DetalleCompraId");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.CompraId).HasColumnName("CompraId");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Subtotal).HasColumnName("Subtotal");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");

            // Relationships
            this.HasOptional(t => t.Compra)
                .WithMany(t => t.DetalleCompras)
                .HasForeignKey(d => d.CompraId);
            this.HasOptional(t => t.Producto)
                .WithMany(t => t.DetalleCompras)
                .HasForeignKey(d => d.ProductoId);

        }
    }
}
