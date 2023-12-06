using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

public class UnitOfWorkInfoTerceroEscritura : UnitOfWorkBase, IUnitOfWorkInfoTerceroEscritura
{
    public UnitOfWorkInfoTerceroEscritura(DbContextOptions<UnitOfWorkInfoTerceroEscritura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
