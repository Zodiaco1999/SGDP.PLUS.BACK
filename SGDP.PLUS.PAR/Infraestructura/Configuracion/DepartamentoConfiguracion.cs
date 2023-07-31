using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Infraestructura.Configuracion
{
    public class DepartamentoConfiguracion : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento", "maestras");

            builder.Property(e => e.DepartamentoId).ValueGeneratedNever();

            builder.Property(e => e.Nombre).HasMaxLength(50);

            builder.Property(e => e.Codigo).HasMaxLength(10);

            builder.HasOne(d => d.Pais).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK_Departamento_Pais");
        }
    }
}
