using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class DetalleVentaMap : EntityTypeConfiguration<DetalleVenta>
    {
        public DetalleVentaMap()
        {
            // Primary Key
            this.HasKey(t => t.DetalleVentaId);

            // Properties
            // Table & Column Mappings
            this.ToTable("DetalleVenta");
            this.Property(t => t.DetalleVentaId).HasColumnName("DetalleVentaId");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.VentaId).HasColumnName("VentaId");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.Subtotal).HasColumnName("Subtotal");

            // Relationships
            this.HasOptional(t => t.Producto)
                .WithMany(t => t.DetalleVentas)
                .HasForeignKey(d => d.ProductoId);
            this.HasOptional(t => t.Venta)
                .WithMany(t => t.DetalleVentas)
                .HasForeignKey(d => d.VentaId);

        }
    }
}
