using SEG.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Repositorio;

public class UsuarioSesionLogRepositorioLectura : Repository<UsuarioSesionLog>, IUsuarioSesionLogRepositorioLectura
{
    public UsuarioSesionLogRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}