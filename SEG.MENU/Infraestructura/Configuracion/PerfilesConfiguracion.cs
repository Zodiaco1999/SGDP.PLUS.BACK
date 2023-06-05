using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SEG.MENU.Dominio.Entidades;
using SEG.Comun.General;
using static Amazon.S3.Util.S3EventNotification;

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
