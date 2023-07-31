using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Repositorio;

public class CargoRepositorioEscritura : Repository<Cargo>, ICargoRepositorioEscritura
{
    public CargoRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}