using SEG.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Repositorio;

public class UsuarioSesionRepositorioLectura : Repository<UsuarioSesion>, IUsuarioSesionRepositorioLectura
{
    public UsuarioSesionRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }

}