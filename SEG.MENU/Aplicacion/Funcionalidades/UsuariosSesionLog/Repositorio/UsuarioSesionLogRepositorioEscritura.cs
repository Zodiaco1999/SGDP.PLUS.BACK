using SEG.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Repositorio;

public class UsuarioSesionLogRepositorioEscritura : Repository<UsuarioSesionLog>, IUsuarioSesionLogRepositorioEscritura
{
    public UsuarioSesionLogRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}