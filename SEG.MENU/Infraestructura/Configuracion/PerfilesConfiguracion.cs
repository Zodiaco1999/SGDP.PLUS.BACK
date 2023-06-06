using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Infraestructura.Configuracion;

public class PerfilesConfiguracion : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable("Perfil", "seg");

        builder.Property(e => e.PerfilId).ValueGeneratedNever();
        builder.Property(e => e.DescPerfil).HasMaxLength(250);
        builder.Property(e => e.NombrePerfil).HasMaxLength(50);
    }
}
