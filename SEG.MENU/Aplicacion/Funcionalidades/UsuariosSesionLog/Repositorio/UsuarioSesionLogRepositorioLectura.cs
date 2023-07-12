using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Repositorio;

public class UsuarioSesionLogRepositorioLectura : Repository<UsuarioSesionLog>, IUsuarioSesionLogRepositorioLectura
{
    public UsuarioSesionLogRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}