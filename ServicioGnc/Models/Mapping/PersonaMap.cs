using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ServicioGnc.Models.Mapping
{
    public class PersonaMap : EntityTypeConfiguration<Persona>
    {
        public PersonaMap()
        {
            // Primary Key
            this.HasKey(t => t.PersonaId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(50);

            this.Property(t => t.Apellido)
                .HasMaxLength(50);

            this.Property(t => t.Domicilio)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Persona");
            this.Property(t => t.PersonaId).HasColumnName("PersonaId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.RolId).HasColumnName("RolId");
            this.Property(t => t.Apellido).HasColumnName("Apellido");
            this.Property(t => t.Domicilio).HasColumnName("Domicilio");
            this.Property(t => t.FechaNacimiento).HasColumnName("FechaNacimiento");
            this.Property(t => t.FechaEgreso).HasColumnName("FechaEgreso");
            this.Property(t => t.FechaIngreso).HasColumnName("FechaIngreso");

            // Relationships
            this.HasOptional(t => t.Rol)
                .WithMany(t => t.Personas)
                .HasForeignKey(d => d.RolId);

        }
    }
}
