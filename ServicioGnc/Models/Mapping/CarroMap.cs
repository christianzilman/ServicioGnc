using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class CarroMap : EntityTypeConfiguration<Carro>
    {
        public CarroMap()
        {
            // Primary Key
            this.HasKey(t => t.CarroId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Carro");
            this.Property(t => t.CarroId).HasColumnName("CarroId");
            this.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            this.Property(t => t.ProductoId).HasColumnName("ProductoId");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");
            this.Property(t => t.Cantidad).HasColumnName("Cantidad");
            this.Property(t => t.TipoOperacionId).HasColumnName("TipoOperacionId");

            // Relationships
            this.HasOptional(t => t.Producto)
                .WithMany(t => t.Carroes)
                .HasForeignKey(d => d.ProductoId);

        }
    }
}
