using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;

    public class UsuarioPerfilRepositorioLectura : Repository<UsuarioPerfil>, IUsuarioPerfilRepositorioLectura
    {
        public UsuarioPerfilRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork)
        {

        }
    }

