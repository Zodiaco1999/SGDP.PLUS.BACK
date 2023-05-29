using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Infraestructura.Configuracion;

public class ModulosConfiguracion : IEntityTypeConfiguration<Modulo>
{
    public void Configure(EntityTypeBuilder<Modulo> builder)
    {
        builder.ToTable("Modulo", "menu");

        builder.HasKey(c => new { c.AplicacionId, c.ModuloId }).HasName("PK_Modulo");

        builder.Property(c => c.NombreModulo).IsRequired().HasMaxLength(50);
        builder.Property(c => c.DescModulo).IsRequired().HasMaxLength(50);

        builder.HasOne(d => d.Apliation)
                .WithMany(p => p.Modulos)
                .HasForeignKey(d => new { d.AplicacionId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modulo_Aplication");
    }
}
