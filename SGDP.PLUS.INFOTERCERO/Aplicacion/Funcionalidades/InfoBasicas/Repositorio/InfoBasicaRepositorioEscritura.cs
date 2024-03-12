using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.INFOTERCERO.Dominio.Entidades;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.InfoBasicas.Repositorio;

public class InfoBasicaRepositorioEscritura : Repository<InfoBasica>, IInfoBasicaRepositorioEscritura
{
    public InfoBasicaRepositorioEscritura(IUnitOfWorkInfoTerceroEscritura unitOfWork) : base(unitOfWork)
    {
    }
}
