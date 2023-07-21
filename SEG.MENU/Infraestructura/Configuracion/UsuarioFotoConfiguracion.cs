using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion
{
    public class UsuarioFotoConfiguracion : IEntityTypeConfiguration<UsuarioFoto>
    {
        public void Configure(EntityTypeBuilder<UsuarioFoto> builder) 
        {
            builder.HasKey(e => e.UsuarioId);
            builder.ToTable("UsuarioFoto", "seg");
            builder.Property(e => e.UsuarioId).HasMaxLength(50);

            builder.Property(e => e.Formato).HasMaxLength(50);
            

            builder.HasOne(d => d.Usuario).WithOne(p => p.UsuarioFoto)
                .HasForeignKey<UsuarioFoto>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioFoto_Usuario");
        }
    }
}
