using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Repositorio;

public class UsuarioSesionRepositorioLectura : Repository<UsuarioSesion>, IUsuarioSesionRepositorioLectura
{
    public UsuarioSesionRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }

}