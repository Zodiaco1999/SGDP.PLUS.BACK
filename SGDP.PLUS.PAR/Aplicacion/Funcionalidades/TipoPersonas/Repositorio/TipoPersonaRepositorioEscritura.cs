using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.MAESTROS.Dominio.Entidades;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Repositorio;

public class TipoPersonaRepositorioEscritura : Repository<TipoPersona>, ITipoPersonaRepositorioEscritura
{
    public TipoPersonaRepositorioEscritura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}