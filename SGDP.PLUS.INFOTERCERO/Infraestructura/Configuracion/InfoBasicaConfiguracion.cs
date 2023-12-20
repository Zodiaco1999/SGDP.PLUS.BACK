using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.Configuracion;

public class InfoBasicaConfiguracion : IEntityTypeConfiguration<InfoBasica>
{
    public void Configure(EntityTypeBuilder<InfoBasica> builder)
    {
        builder.ToTable("InfoBasica", "infotercero");

        builder.HasKey(e => new { e.Nit, e.Ici }).HasName("PK__InfoBasi__C7D1D6DB0D4E2D97");

        builder.Property(e => e.Nit).HasMaxLength(200);
        builder.Property(e => e.Ici).HasMaxLength(200);
        builder.Property(e => e.Actividad).HasMaxLength(500);
        builder.Property(e => e.Ciudad).HasMaxLength(200);
        builder.Property(e => e.Denominacion).HasMaxLength(400);
        builder.Property(e => e.DomicilioSocial).HasMaxLength(500);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.FechaConstitucion).HasColumnType("datetime");
        builder.Property(e => e.FormaJuridicaCod).HasMaxLength(50);
        builder.Property(e => e.IdFiscal).HasMaxLength(200);
        builder.Property(e => e.Telefono).HasMaxLength(200);
    }

}
