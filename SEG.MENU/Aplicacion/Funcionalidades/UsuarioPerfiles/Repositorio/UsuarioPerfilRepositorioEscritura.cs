using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;

    public class UsuarioPerfilRepositorioEscritura : Repository<UsuarioPerfil>, IUsuarioPerfilRepositorioEscritura
    {
        public UsuarioPerfilRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
        {
        
        }
    }

