using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEG.Comun.General;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion
{
    public class TipoDocumentoConfiguracion : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder) 
        {
            builder.HasKey(e => e.TipoDocumentoId).HasName("PK_TIPODOCUMENTO");

            builder.ToTable("TipoDocumento", "maestras");

            builder.Property(e => e.TipoDocumentoId).ValueGeneratedNever();
            builder.Property(e => e.Abreviatura).HasMaxLength(10);
            builder.Property(e => e.Nombre).HasMaxLength(50);
        }
    }
}
