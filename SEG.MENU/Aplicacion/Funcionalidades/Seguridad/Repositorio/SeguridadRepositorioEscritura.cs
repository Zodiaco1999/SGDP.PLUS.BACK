using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Repositorio;
public class SeguridadRepositorioEscritura : Repository<Usuario>, ISeguridadRepositorioEscritura
{
    public SeguridadRepositorioEscritura(IUnitOfWorkSegEscritura unitOfWork) : base(unitOfWork)
    {
    }
}