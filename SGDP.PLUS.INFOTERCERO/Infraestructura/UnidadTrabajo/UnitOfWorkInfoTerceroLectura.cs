using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

public class UnitOfWorkInfoTerceroLectura : UnitOfWorkBase, IUnitOfWorkInfoTerceroLectura
{
    public UnitOfWorkInfoTerceroLectura(DbContextOptions<UnitOfWorkInfoTerceroLectura> opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
