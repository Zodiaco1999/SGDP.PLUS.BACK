using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Repositorio;

public class UsuarioSesionRepositorioEscritura : Repository<UsuarioSesion>, IUsuarioSesionRepositorioEscritura
{
    public UsuarioSesionRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}