using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Repositorio;

public class CiudadRepositorioEscritura : Repository<Ciudad>, ICiudadRepositorioEscritura
{
    public CiudadRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}