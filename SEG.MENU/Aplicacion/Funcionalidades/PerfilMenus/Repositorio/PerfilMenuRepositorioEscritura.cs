using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;

public class PerfilMenuRepositorioEscritura : Repository<PerfilMenu>, IPerfilMenuRepositorioEscritura
{
    public PerfilMenuRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
    {
    }
}
