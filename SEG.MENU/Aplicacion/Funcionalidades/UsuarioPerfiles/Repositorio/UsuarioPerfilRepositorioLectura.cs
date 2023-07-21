using SEG.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;

    public class UsuarioPerfilRepositorioLectura : Repository<UsuarioPerfil>, IUsuarioPerfilRepositorioLectura
    {
        public UsuarioPerfilRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork)
        {

        }
    }

