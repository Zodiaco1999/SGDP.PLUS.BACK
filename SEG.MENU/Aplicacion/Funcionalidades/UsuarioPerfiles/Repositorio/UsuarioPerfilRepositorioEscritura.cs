using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;

    public class UsuarioPerfilRepositorioEscritura : Repository<UsuarioPerfil>, IUsuarioPerfilRepositorioEscritura
    {
        public UsuarioPerfilRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
        {
        
        }
    }

