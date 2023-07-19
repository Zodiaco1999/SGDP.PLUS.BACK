using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.Repositorio;

public class MenuRepositorioLectura : Repository<Menu>, IMenuRepositorioLectura
{
    public MenuRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}