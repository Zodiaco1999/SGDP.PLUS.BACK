using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.Repositorio;

public class ModuloRepositorioLectura : Repository<Modulo>, IModuloRepositorioLectura
{
    public ModuloRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}