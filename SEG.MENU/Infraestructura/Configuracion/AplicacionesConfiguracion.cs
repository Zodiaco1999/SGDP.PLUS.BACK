using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion;

public class AplicacionesConfiguracion : IEntityTypeConfiguration<Aplication>
{
    public void Configure(EntityTypeBuilder<Aplication> builder)
    {
        builder.ToTable("Aplicacion","menu");
        builder.HasKey(c => c.AplicacionId);
        builder.Property(c => c.NombreAplicacion).IsRequired()
           .HasMaxLength(200);

        builder.HasIndex(uq => uq.AplicacionId).IsUnique();
    }
}
