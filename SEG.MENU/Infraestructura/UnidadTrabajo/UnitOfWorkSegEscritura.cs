﻿using Microsoft.EntityFrameworkCore;
using SEG.Comun.ContextAccesor;
using SEG.Comun.UnidadTrabajo;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.Configuracion;

namespace SEG.MENU.Infraestructura.UnidadTrabajo;

public class UnitOfWorkSegEscritura : UnitOfWorkBase, IUnitOfWorkSegEscritura
{
    public UnitOfWorkSegEscritura(DbContextOptions<UnitOfWorkSegEscritura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }
    public virtual DbSet<Aplication> Aplication { get; set; }
    public virtual DbSet<Modulo> Modulo { get; set; }
    public virtual DbSet<Perfil> Perfil { get; set; }
    public virtual DbSet<Menu> Menu { get; set; }
    public virtual DbSet<PerfilMenu> PerfilMenu { get; set; }
    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<UsuarioFoto> UsuarioFotos { get; set; }
    public virtual DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }
    public virtual DbSet<UsuarioSesion> UsuarioSesions { get; set; }
    public virtual DbSet<UsuarioSesionLog> UsuarioSesionLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Seg
        modelBuilder.ApplyConfiguration(new AplicacionesConfiguracion());
        modelBuilder.ApplyConfiguration(new ModulosConfiguracion());
        modelBuilder.ApplyConfiguration(new PerfilesConfiguracion());
        modelBuilder.ApplyConfiguration(new MenusConfiguracion());
        modelBuilder.ApplyConfiguration(new PerfilMenusConfiguracion());
        modelBuilder.ApplyConfiguration(new TipoDocumentoConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioFotoConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioPerfilConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioSesionConfiguracion());
        modelBuilder.ApplyConfiguration(new UsuarioSesionLogConfiguracion());
        #endregion

    }
}