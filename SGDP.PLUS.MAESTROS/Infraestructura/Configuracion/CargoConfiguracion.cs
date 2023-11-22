using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.MAESTROS.Infraestructura.Configuracion
{
    public class CargoConfiguracion : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("Cargo", "maestras");

            builder.Property(e => e.CargoId).ValueGeneratedNever();

            builder.Property(e => e.Nombre).HasMaxLength(50);

            builder.Property(e => e.Abreviatura).HasMaxLength(10);
            
        }
    }
}
