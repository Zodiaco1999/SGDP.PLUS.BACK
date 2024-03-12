using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Repositorio;

public class IlicitosRespuestaLectura : Repository<IlicitosRespuesta>, IIlicitosRespuestaLectura
{
    public IlicitosRespuestaLectura(IUnitOfWorkInfoTerceroLectura unitOfWork) : base(unitOfWork)
    {
    }
}
