using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;

namespace SGDP.PLUS.MAESTROS.Infraestructura.Configuracion
{
    public class PaisConfiguracion : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Pais", "maestras");

            builder.Property(e => e.PaisId).ValueGeneratedNever();

            builder.Property(e => e.Nombre).HasMaxLength(50);

            builder.Property(e => e.Codigo).HasMaxLength(10);

        }
    }
}
