using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio
{
    public class AplicationRepositorioLectura : Repository<Aplication>, IAplicationRepositorioLectura
    {
        public AplicationRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork)
        {
        }
    }
}
