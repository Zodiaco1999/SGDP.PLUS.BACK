using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.Repositorio;

public class ApiRepositorioLectura : Repository<Api>, IApiRepositorioLectura
{
    public ApiRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}