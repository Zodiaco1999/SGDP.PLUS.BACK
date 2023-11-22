using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Infraestructura.Configuracion
{
    public class TipoPersonaConfiguracion : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable("TipoPersona", "maestras");

            builder.Property(e => e.TipoPersonaId).ValueGeneratedNever();
           
            builder.Property(e => e.NombreTipo).HasMaxLength(50);
        }
    }
}
