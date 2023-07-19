using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.Repositorio;

public class ModuloRepositorioEscritura : Repository<Modulo>, IModuloRepositorioEscritura
{
    public ModuloRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}