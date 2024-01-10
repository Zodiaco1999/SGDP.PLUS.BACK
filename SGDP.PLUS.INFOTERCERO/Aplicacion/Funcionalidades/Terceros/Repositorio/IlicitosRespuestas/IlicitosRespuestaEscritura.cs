using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.Repositorio.IlicitosRespuestas;

public class IlicitosRespuestaEscritura : Repository<IlicitosRespuesta>, IIlicitosRespuestaEscritura
{
    public IlicitosRespuestaEscritura(IUnitOfWorkInfoTerceroEscritura unitOfWork) : base(unitOfWork)
    {
    }
}
