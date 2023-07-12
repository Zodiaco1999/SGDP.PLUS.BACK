using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Repositorio;

public class UsuarioSesionLogRepositorioEscritura : Repository<UsuarioSesionLog>, IUsuarioSesionLogRepositorioEscritura
{
    public UsuarioSesionLogRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}