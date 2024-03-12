using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.Comun.UnidadTrabajo;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Repositorio;

public class RespuestaLaftRepositorioEscritura : Repository<RespuestaLaft>, IRespuestaLaftRepositorioEscritura
{
    public RespuestaLaftRepositorioEscritura(IUnitOfWorkInfoTerceroEscritura unitOfWork) : base(unitOfWork)
    {
    }
}
