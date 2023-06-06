using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Repositorio;

public class PerfilRepositorioEscritura : Repository<Perfil>, IPerfilRepositorioEscritura
{
    public PerfilRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
    {
    }
}
