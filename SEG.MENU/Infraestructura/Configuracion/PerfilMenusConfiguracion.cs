using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion;

public class PerfilMenusConfiguracion : IEntityTypeConfiguration<PerfilMenu>
{
    public void Configure(EntityTypeBuilder<PerfilMenu> builder)
    {
        builder.HasKey(e => e.PerfilId);
        builder.ToTable("PerfilMenu", "seg");
        builder.Property(e => e.PerfilId).ValueGeneratedNever();

        builder.HasOne(d => d.Perfil).WithOne(p => p.PerfilMenu)
            .HasForeignKey<PerfilMenu>(d => d.PerfilId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PerfilMenu_Perfil");

        builder.HasOne(d => d.Menu).WithMany(p => p.PerfilMenus)
            .HasForeignKey(d => new { d.AplicacionId, d.ModuloId, d.MenuId })
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_PerfilMenu_Menu");
    }
}