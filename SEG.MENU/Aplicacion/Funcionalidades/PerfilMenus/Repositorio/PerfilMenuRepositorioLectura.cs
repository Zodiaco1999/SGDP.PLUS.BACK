using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;

public class PerfilMenuRepositorioLectura : Repository<PerfilMenu>, IPerfilMenuRepositorioLectura
{
    public PerfilMenuRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork)
    {
    }
}
