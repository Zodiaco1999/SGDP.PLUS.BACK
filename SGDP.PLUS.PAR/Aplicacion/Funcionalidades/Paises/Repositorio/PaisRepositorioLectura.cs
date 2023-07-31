using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Repositorio;

public class PaisRepositorioLectura : Repository<Pais>, IPaisRepositorioLectura
{
    public PaisRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}