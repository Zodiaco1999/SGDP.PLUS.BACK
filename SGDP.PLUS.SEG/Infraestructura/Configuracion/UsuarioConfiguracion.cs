﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "seg");

            builder.Property(e => e.UsuarioId).HasMaxLength(50);
            builder.Property(e => e.CodigoAsignacion).HasMaxLength(50);
            builder.Property(e => e.Email).HasMaxLength(50);
            builder.Property(e => e.FechaActualizacionContrasena).HasColumnType("datetime");
            builder.Property(e => e.FechaBloqueo).HasColumnType("datetime");
            builder.Property(e => e.FechaNacimiento).HasColumnType("date");
            builder.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsFixedLength();
            builder.Property(e => e.LogearLdap).HasColumnName("LogearLDAP");
            builder.Property(e => e.NumeroIdentificacion).HasMaxLength(20);
            builder.Property(e => e.PrimerApellido).HasMaxLength(50);
            builder.Property(e => e.PrimerNombre).HasMaxLength(250);
            builder.Property(e => e.SegundoApellido).HasMaxLength(50);
            builder.Property(e => e.SegundoNombre).HasMaxLength(50);
            builder.Property(e => e.UsuarioDominio).HasMaxLength(50);
            builder.Property(e => e.VenceCodigoAsignacion).HasColumnType("datetime");

            builder.HasOne(d => d.TipoDocumento).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoDocumentoId)
                .HasConstraintName("FK_Usuario_TipoDocumento");
        }
    }
}
