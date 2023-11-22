using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion
{
    public class UsuarioSesionLogConfiguracion : IEntityTypeConfiguration<UsuarioSesionLog>
    {
        public void Configure(EntityTypeBuilder<UsuarioSesionLog> builder) 
        {
            builder.HasKey(e => e.LogId);

            builder.ToTable("UsuarioSesionLog", "seg");

            builder.Property(e => e.LogId).ValueGeneratedNever();
            builder.Property(e => e.Accion).HasMaxLength(250);
            builder.Property(e => e.Fecha).HasColumnType("datetime");
            builder.Property(e => e.IpCliente).HasMaxLength(50);
            builder.Property(e => e.MsgValidacion).HasMaxLength(250);
            builder.Property(e => e.SesionId).HasMaxLength(50);
            builder.Property(e => e.UsuarioId).HasMaxLength(50);

            builder.HasOne(d => d.UsuarioSesion).WithMany(p => p.UsuarioSesionLogs)
                .HasForeignKey(d => new { d.UsuarioId, d.SesionId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fk_UsuarioSesionLog_UsuarioSesion");
        }
    }
}
