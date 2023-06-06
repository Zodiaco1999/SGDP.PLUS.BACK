using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;


public class AplicationRepositorioEscritura : Repository<Aplication>, IAplicationRepositorioEscritura
{
    public AplicationRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
    {
    }
}