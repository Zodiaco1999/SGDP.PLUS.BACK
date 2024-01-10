using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.Configuracion;

public class IlicitosRespuestaConfiguracion : IEntityTypeConfiguration<IlicitosRespuesta>
{
    public void Configure(EntityTypeBuilder<IlicitosRespuesta> builder)
    {
        builder.ToTable("IlicitosRespuesta", "infotercero");

        builder.HasKey(e => new { e.RespuestaLaftId, e.NumReg });

        builder.Property(e => e.NumReg).HasMaxLength(4);
        builder.Property(e => e.Alias).HasMaxLength(500);
        builder.Property(e => e.Ciudad).HasMaxLength(200);
        builder.Property(e => e.Coincidencia).HasMaxLength(50);
        builder.Property(e => e.ConsultaRealizada).HasMaxLength(50);
        builder.Property(e => e.DelitoOcausa).HasColumnName("DelitoOCausa");
        builder.Property(e => e.FechaCarga).HasMaxLength(100);
        builder.Property(e => e.FechaPublicacion).HasMaxLength(100);
        builder.Property(e => e.Fuente).HasMaxLength(2000);
        builder.Property(e => e.IdentificacionEncontrada).HasMaxLength(50);
        builder.Property(e => e.Lista).HasMaxLength(2000);
        builder.Property(e => e.NombreEncontrado).HasMaxLength(200);
        builder.Property(e => e.PorcentajeCoincidencia).HasMaxLength(3);

        builder.HasOne(d => d.RespuestaLaft).WithMany(p => p.IlicitosRespuesta)
            .HasForeignKey(d => d.RespuestaLaftId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_IlicitosRespuesta_RespuestaLaft");
    }
}
