using Microsoft.EntityFrameworkCore;
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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        #region Seg
        modelBuilder.ApplyConfiguration(new AplicacionesConfiguracion());
        modelBuilder.ApplyConfiguration(new ModulosConfiguracion());
        #endregion
    }
}