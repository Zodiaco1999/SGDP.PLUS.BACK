using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEG.Comun.General;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Infraestructura.Configuracion
{
    public class TipoDocumentoConfiguracion : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder) 
        {
            builder.HasKey(e => e.TipoDocumentoId).HasName("PK_TIPODOCUMENTO");

            builder.ToTable("TipoDocumento", "maestras");

            builder.Property(e => e.TipoDocumentoId).ValueGeneratedNever();
            builder.Property(e => e.Abreviatura).HasMaxLength(10);
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
            builder.Property(e => e.Nombre).HasMaxLength(50);
        }
    }
}
