using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Infraestructura.Configuracion
{
    public class UsuarioFotoConfiguracion : IEntityTypeConfiguration<UsuarioFoto>
    {
        public void Configure(EntityTypeBuilder<UsuarioFoto> builder) 
        {
            builder.HasKey(e => e.UsuarioId);
            builder.ToTable("UsuarioFoto", "seg");
            builder.Property(e => e.UsuarioId).HasMaxLength(50);

            builder.Property(e => e.CreaFecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.CreaMaquina)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(host_name())");
            builder.Property(e => e.CreaUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");
            builder.Property(e => e.Formato).HasMaxLength(50);
            builder.Property(e => e.ModificaFecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.ModificaMaquina)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(host_name())");
            builder.Property(e => e.ModificaUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(suser_name())");

            builder.HasOne(d => d.Usuario).WithOne(p => p.UsuarioFoto)
                .HasForeignKey<UsuarioFoto>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioFoto_Usuario");
        }
    }
}
