using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion;

public class ApiConfiguracion : IEntityTypeConfiguration<Api>
{
    public void Configure(EntityTypeBuilder<Api> builder)
    {
        builder.ToTable("Api", "menu");

        builder.HasKey(e => new { e.ApiId, e.AplicacionId }).HasName("PK_API");

        builder.Property(e => e.NombreApi).IsRequired().HasMaxLength(50);
        builder.Property(e => e.DescripcionApi).HasMaxLength(200);
        builder.Property(e => e.UrlProduccion).HasMaxLength(200);
        builder.Property(e => e.UrlPrueba).HasMaxLength(200);

        builder.HasOne(d => d.Aplication).WithMany(p => p.Apis)
            .HasForeignKey(d => d.AplicacionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Api_Aplicacion");
    }
}

