using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
 public class UsuarioFotoRepositorioLectura : Repository<UsuarioFoto>, IUsuarioFotoRepositorioLectura
 {
    public UsuarioFotoRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork) 
    { 

    }
 }
