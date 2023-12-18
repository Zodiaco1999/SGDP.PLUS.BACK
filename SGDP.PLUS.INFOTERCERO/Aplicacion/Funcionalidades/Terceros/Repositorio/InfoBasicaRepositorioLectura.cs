using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.Repositorio;

public class InfoBasicaRepositorioLectura : Repository<InfoBasica>, IInfoBasicaRepositorioLectura
{
    public InfoBasicaRepositorioLectura(IUnitOfWorkInfoTerceroLectura unitOfWork) : base(unitOfWork)
    { 
    }
}
