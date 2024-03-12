using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Repositorio;

public class RespuestaLaftRepositorioLectura : Repository<RespuestaLaft>, IRespuestaLaftRepositorioLectura
{
    public RespuestaLaftRepositorioLectura(IUnitOfWorkInfoTerceroLectura unitOfWork) : base(unitOfWork)
    {
    }
}
