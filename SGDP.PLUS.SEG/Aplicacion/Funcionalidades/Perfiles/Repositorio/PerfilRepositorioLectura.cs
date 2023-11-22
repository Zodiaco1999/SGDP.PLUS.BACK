using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Repositorio;

public class PerfilRepositorioLectura : Repository<Perfil>, IPerfilRepositorioLectura
{
    public PerfilRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork)
    {
    }
}
