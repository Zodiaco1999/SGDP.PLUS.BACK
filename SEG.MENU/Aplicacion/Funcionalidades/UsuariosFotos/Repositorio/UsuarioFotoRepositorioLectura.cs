using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.UnidadTrabajo;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
 public class UsuarioFotoRepositorioLectura : Repository<UsuarioFoto>, IUsuarioFotoRepositorioLectura
 {
    public UsuarioFotoRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork) 
    { 

    }
 }
