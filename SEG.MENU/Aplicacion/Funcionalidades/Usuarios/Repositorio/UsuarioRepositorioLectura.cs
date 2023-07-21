using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Repositorio;

public class UsuarioRepositorioLectura : Repository<Usuario>, IUsuarioRepositorioLectura
{
    public UsuarioRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}