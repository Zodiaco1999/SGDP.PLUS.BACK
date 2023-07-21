using SEG.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
 public class UsuarioFotoRepositorioEscritura : Repository<UsuarioFoto>, IUsuarioFotoRepositorioEscritura
 {
    public UsuarioFotoRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
    {
    
    }
 }

