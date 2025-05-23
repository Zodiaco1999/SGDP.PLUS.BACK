﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Infraestructura.Configuracion
{
    public class UsuarioPerfilConfiguracion : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.HasKey(e => new { e.UsuarioId, e.PerfilId });

            builder.ToTable("UsuarioPerfil", "seg");

            builder.Property(e => e.UsuarioId).HasMaxLength(50);
            builder.Property(e => e.FechaInicia).HasColumnType("date");
            builder.Property(e => e.FechaTermina).HasColumnType("date");

            builder.HasOne(d => d.Perfil).WithMany(p => p.UsuarioPerfiles)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioPerfil_Perfil");

            builder.HasOne(d => d.Usuario).WithMany(p => p.UsuarioPerfiles)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_UsuarioPerfil_Usuario");
        }
    }
}
