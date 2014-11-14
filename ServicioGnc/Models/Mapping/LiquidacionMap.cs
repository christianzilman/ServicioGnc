using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class LiquidacionMap : EntityTypeConfiguration<Liquidacion>
    {
        public LiquidacionMap()
        {
            // Primary Key
            this.HasKey(t => t.LiquidacionId);

            // Properties
            this.Property(t => t.Periodo)
                .IsFixedLength()
                .HasMaxLength(7);

            // Table & Column Mappings
            this.ToTable("Liquidacion");
            this.Property(t => t.LiquidacionId).HasColumnName("LiquidacionId");
            this.Property(t => t.PersonaId).HasColumnName("PersonaId");
            this.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.Periodo).HasColumnName("Periodo");
            this.Property(t => t.Fecha).HasColumnName("Fecha");

            // Relationships
            this.HasOptional(t => t.Empresa)
                .WithMany(t => t.Liquidacions)
                .HasForeignKey(d => d.EmpresaId);
            this.HasOptional(t => t.Persona)
                .WithMany(t => t.Liquidacions)
                .HasForeignKey(d => d.PersonaId);

        }
    }
}
