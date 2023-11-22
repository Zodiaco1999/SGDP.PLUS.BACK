using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion;

public class MenusConfiguracion : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menu", "menu");

        builder.HasKey(e => new { e.AplicacionId, e.ModuloId, e.MenuId });

        builder.Property(e => e.DescMenu).HasMaxLength(250);
        builder.Property(e => e.EtiquetaMenu).HasMaxLength(50);
        builder.Property(e => e.NombreMenu).HasMaxLength(50);
        builder.Property(e => e.Url).HasMaxLength(250);

        builder.HasOne(d => d.Modulo).WithMany(p => p.Menus)
            .HasForeignKey(d => new { d.AplicacionId, d.ModuloId })
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Menu_Modulo");
    }
}

