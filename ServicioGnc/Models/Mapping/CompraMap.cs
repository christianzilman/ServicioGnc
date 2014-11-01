using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class CompraMap : EntityTypeConfiguration<Compra>
    {
        public CompraMap()
        {
            // Primary Key
            this.HasKey(t => t.CompraId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Compra");
            this.Property(t => t.CompraId).HasColumnName("CompraId");
            this.Property(t => t.ProveedorId).HasColumnName("ProveedorId");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Total).HasColumnName("Total");

            // Relationships
            this.HasRequired(t => t.Proveedor)
                .WithMany(t => t.Compras)
                .HasForeignKey(d => d.ProveedorId);

        }
    }
}
