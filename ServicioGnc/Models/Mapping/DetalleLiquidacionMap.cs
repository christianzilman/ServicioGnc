using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class DetalleLiquidacionMap : EntityTypeConfiguration<DetalleLiquidacion>
    {
        public DetalleLiquidacionMap()
        {
            // Primary Key
            this.HasKey(t => t.DetalleLiquidacionId);

            // Properties
            // Table & Column Mappings
            this.ToTable("DetalleLiquidacion");
            this.Property(t => t.DetalleLiquidacionId).HasColumnName("DetalleLiquidacionId");
            this.Property(t => t.LiquidacionId).HasColumnName("LiquidacionId");
            this.Property(t => t.ConceptoId).HasColumnName("ConceptoId");
            this.Property(t => t.SubTotal).HasColumnName("SubTotal");

            // Relationships
            this.HasOptional(t => t.Concepto)
                .WithMany(t => t.DetalleLiquidacions)
                .HasForeignKey(d => d.ConceptoId);
            this.HasOptional(t => t.Liquidacion)
                .WithMany(t => t.DetalleLiquidacions)
                .HasForeignKey(d => d.LiquidacionId);

        }
    }
}
