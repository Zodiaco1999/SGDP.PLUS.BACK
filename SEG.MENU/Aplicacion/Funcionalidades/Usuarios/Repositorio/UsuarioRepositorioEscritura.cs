using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Repositorio;

public class UsuarioRepositorioEscritura : Repository<Usuario>, IUsuarioRepositorioEscritura
{
    public UsuarioRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}