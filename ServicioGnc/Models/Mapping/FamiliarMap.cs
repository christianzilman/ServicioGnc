using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class FamiliarMap : EntityTypeConfiguration<Familiar>
    {
        public FamiliarMap()
        {
            // Primary Key
            this.HasKey(t => t.FamiliarId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(200);

            this.Property(t => t.Relacion)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Familiar");
            this.Property(t => t.FamiliarId).HasColumnName("FamiliarId");
            this.Property(t => t.PersonaId).HasColumnName("PersonaId");
            this.Property(t => t.Dni).HasColumnName("Dni");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.Relacion).HasColumnName("Relacion");
            this.Property(t => t.FechaNacimiento).HasColumnName("FechaNacimiento");

            // Relationships
            this.HasOptional(t => t.Persona)
                .WithMany(t => t.Familiars)
                .HasForeignKey(d => d.PersonaId);

        }
    }
}
