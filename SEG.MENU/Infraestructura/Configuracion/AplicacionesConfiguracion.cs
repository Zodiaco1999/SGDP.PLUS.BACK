using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Infraestructura.Configuracion;

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
