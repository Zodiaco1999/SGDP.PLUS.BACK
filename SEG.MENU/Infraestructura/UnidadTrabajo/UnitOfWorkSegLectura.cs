using Microsoft.EntityFrameworkCore;
using SEG.Comun.ContextAccesor;
using SEG.Comun.UnidadTrabajo;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.Configuracion;

namespace SEG.MENU.Infraestructura.UnidadTrabajo;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Seg
        modelBuilder.ApplyConfiguration(new AplicacionesConfiguracion());
        modelBuilder.ApplyConfiguration(new ModulosConfiguracion());
        modelBuilder.ApplyConfiguration(new ApiConfiguracion());
        modelBuilder.ApplyConfiguration(new PerfilesConfiguracion());
        modelBuilder.ApplyConfiguration(new MenusConfiguracion());
        modelBuilder.ApplyConfiguration(new PerfilMenusConfiguracion());
        #endregion
    }
}