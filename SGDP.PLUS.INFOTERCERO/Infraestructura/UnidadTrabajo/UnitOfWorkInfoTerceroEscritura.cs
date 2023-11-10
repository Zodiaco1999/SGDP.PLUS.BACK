using Microsoft.EntityFrameworkCore;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.UnidadTrabajo;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

public class UnitOfWorkInfoTerceroEscritura : UnitOfWorkBase, IUnitOfWorkInfoTerceroEscritura
{
    public UnitOfWorkInfoTerceroEscritura(DbContextOptions opcionesDBContext, IContextAccessor contextAccessor = null) : base(opcionesDBContext, contextAccessor)
    {
    }
}
