using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.Configuracion;

public class RespuestaLaftConfiguracion : IEntityTypeConfiguration<RespuestaLaft>
{
    public void Configure(EntityTypeBuilder<RespuestaLaft> builder)
    {
        builder.ToTable("RespuestaLaft", "infotercero");

        builder.HasKey(e => e.RespuestaLaftId).HasName("PK_RespuestaLaft_1");

        builder.Property(e => e.RespuestaLaftId).ValueGeneratedNever();
        builder.Property(e => e.CodigoInforma).HasMaxLength(100);
        builder.Property(e => e.IdentificacionConsultada).HasMaxLength(50);
        builder.Property(e => e.FechaSolicitud).HasColumnType("datetime");
        builder.Property(e => e.IdUsuarioSolicitud).HasMaxLength(50);
        builder.Property(e => e.NitTerceroAplica).HasMaxLength(50);
        builder.Property(e => e.RespuestaJson).HasColumnName("Respuesta_Json");

        builder.HasOne(d => d.NitTerceroAplicaNavigation).WithMany(p => p.RespuestaLafts)
            .HasForeignKey(d => d.NitTerceroAplica)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RespuestaLaft_InfoBasica");
    }
}
