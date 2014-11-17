using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class VentaMap : EntityTypeConfiguration<Venta>
    {
        public VentaMap()
        {
            // Primary Key
            this.HasKey(t => t.VentaId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Venta");
            this.Property(t => t.VentaId).HasColumnName("VentaId");
            this.Property(t => t.Fecha).HasColumnName("Fecha");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            this.Property(t => t.TipoEstadoId).HasColumnName("TipoEstadoId");

            // Relationships
            this.HasOptional(t => t.Cliente)
                .WithMany(t => t.Ventas)
                .HasForeignKey(d => d.ClienteId);
            this.HasOptional(t => t.TipoEstado)
                .WithMany(t => t.Ventas)
                .HasForeignKey(d => d.TipoEstadoId);

        }
    }
}
