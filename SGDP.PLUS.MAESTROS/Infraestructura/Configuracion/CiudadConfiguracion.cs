using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Infraestructura.Configuracion
{
    public class CiudadConfiguracion : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.ToTable("Ciudad", "maestras");

            builder.Property(e => e.CiudadId).ValueGeneratedNever();

            builder.Property(e => e.Nombre).HasMaxLength(10);

            builder.Property(e => e.Codigo).HasMaxLength(10);

            builder.HasOne(d => d.Departamento).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK_Ciudad_Departamento");
        }
    }
}
