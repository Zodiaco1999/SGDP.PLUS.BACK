using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.Configuracion;

public class AdministradorConfiguracion : IEntityTypeConfiguration<Administrador>
{
    public void Configure(EntityTypeBuilder<Administrador> builder)
    {
        builder.HasKey(e => e.AdministradorId).HasName("PK__Administ__2C780D7624C2058B");

        builder.ToTable("Administrador", "infotercero");

        builder.Property(e => e.AdministradorId).ValueGeneratedNever();
        builder.Property(e => e.Cargo).HasMaxLength(300);
        builder.Property(e => e.Cedula).HasMaxLength(200);
        builder.Property(e => e.CodigoCargo).HasMaxLength(100);
        builder.Property(e => e.FechaCambioAdmin).HasMaxLength(100);
        builder.Property(e => e.FechaNombramiento).HasMaxLength(100);
        builder.Property(e => e.FechaSolicitud).HasColumnType("datetime");
        builder.Property(e => e.NitTercero).HasMaxLength(50);
        builder.Property(e => e.Nombre).HasMaxLength(500);

        builder.HasOne(d => d.InfoBasica).WithMany(p => p.Administradors)
            .HasForeignKey(d => new { d.NitTercero, d.FechaSolicitud })
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Administrador_InfoBasica");
    }
}
