using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
 public class UsuarioFotoRepositorioEscritura : Repository<UsuarioFoto>, IUsuarioFotoRepositorioEscritura
 {
    public UsuarioFotoRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
    {
    
    }
 }

