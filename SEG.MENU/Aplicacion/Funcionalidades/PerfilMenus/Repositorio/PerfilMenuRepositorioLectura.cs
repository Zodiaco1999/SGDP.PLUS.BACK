using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;

public class PerfilMenuRepositorioLectura : Repository<PerfilMenu>, IPerfilMenuRepositorioLectura
{
    public PerfilMenuRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork)
    {
    }
}
