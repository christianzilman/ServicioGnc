using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class FichadaMap : EntityTypeConfiguration<Fichada>
    {
        public FichadaMap()
        {
            // Primary Key
            this.HasKey(t => t.FichadaId);

            // Properties
            this.Property(t => t.Observacion)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Fichada");
            this.Property(t => t.FichadaId).HasColumnName("FichadaId");
            this.Property(t => t.FechaIngreso).HasColumnName("FechaIngreso");
            this.Property(t => t.FechaEgreso).HasColumnName("FechaEgreso");
            this.Property(t => t.PersonaId).HasColumnName("PersonaId");
            this.Property(t => t.Observacion).HasColumnName("Observacion");

            // Relationships
            this.HasOptional(t => t.Persona)
                .WithMany(t => t.Fichadas)
                .HasForeignKey(d => d.PersonaId);

        }
    }
}
