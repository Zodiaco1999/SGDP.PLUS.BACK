using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.Configuracion;

namespace SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

public class UnitOfWorkSegLectura : UnitOfWorkBase, IUnitOfWorkSegLectura
{
    public UnitOfWorkSegLectura(DbContextOptions<UnitOfWorkSegLectura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
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
        modelBuilder.ApplyConfiguration(new ApiConfiguracion());
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