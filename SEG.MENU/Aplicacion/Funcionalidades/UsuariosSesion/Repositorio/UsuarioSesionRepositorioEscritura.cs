using SEG.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Repositorio;

public class UsuarioSesionRepositorioEscritura : Repository<UsuarioSesion>, IUsuarioSesionRepositorioEscritura
{
    public UsuarioSesionRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}