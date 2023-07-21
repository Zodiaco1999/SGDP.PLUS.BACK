using SEG.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Repositorio;

public class UsuarioRepositorioLectura : Repository<Usuario>, IUsuarioRepositorioLectura
{
    public UsuarioRepositorioLectura(IUnitOfWorkSegEscritura  unitOfWork) : base(unitOfWork)
    {
    }
}