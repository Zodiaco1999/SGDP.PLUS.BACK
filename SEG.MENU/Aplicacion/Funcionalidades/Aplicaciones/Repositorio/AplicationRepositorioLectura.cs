using SGDP.PLUS.Comun.Repositorios;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Repositorio
{
    public class AplicationRepositorioLectura : Repository<Aplication>, IAplicationRepositorioLectura
    {
        public AplicationRepositorioLectura(IUnitOfWorkSegLectura unitOfWork) : base(unitOfWork)
        {
        }
    }
}
