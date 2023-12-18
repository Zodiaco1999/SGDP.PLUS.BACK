using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.Configuracion;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

public class UnitOfWorkInfoTerceroEscritura : UnitOfWorkBase, IUnitOfWorkInfoTerceroEscritura
{
    public UnitOfWorkInfoTerceroEscritura(DbContextOptions<UnitOfWorkInfoTerceroEscritura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }

    public virtual DbSet<InfoBasica> InfoBasica { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new InfoBasicaConfiguracion());
    }
}
