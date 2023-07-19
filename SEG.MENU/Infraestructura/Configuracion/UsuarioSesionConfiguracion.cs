using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Infraestructura.Configuracion
{
    public class UsuarioSesionConfiguracion : IEntityTypeConfiguration<UsuarioSesion>
    {
        public void Configure(EntityTypeBuilder<UsuarioSesion> builder) 
        {
            builder.HasKey(e => new { e.UsuarioId, e.SesionId });

            builder.ToTable("UsuarioSesion", "seg");

            builder.Property(e => e.UsuarioId).HasMaxLength(50);
            builder.Property(e => e.SesionId).HasMaxLength(50);
            builder.Property(e => e.InicioSesion).HasColumnType("datetime");
            builder.Property(e => e.IpCliente).HasMaxLength(50);
            builder.Property(e => e.ModificaFecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.TokenActualizacion).HasMaxLength(50);

            builder.HasOne(d => d.Usuario).WithMany(p => p.UsuarioSesions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioSesion_Usuario");
        }
    }
}
