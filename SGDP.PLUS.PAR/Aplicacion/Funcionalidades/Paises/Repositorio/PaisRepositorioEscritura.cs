using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Repositorio;

public class PaisRepositorioEscritura : Repository<Pais>, IPaisRepositorioEscritura
{
    public PaisRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}