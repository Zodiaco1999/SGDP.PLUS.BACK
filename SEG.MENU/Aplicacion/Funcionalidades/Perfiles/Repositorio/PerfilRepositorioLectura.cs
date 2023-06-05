using SEG.Comun.Repositorios;
using SEG.MENU.Dominio.Entidades;
using SEG.MENU.Infraestructura.Context;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Repositorio;

public class PerfilRepositorioLectura : Repository<Perfil>, IPerfilRepositorioLectura
{
    public PerfilRepositorioLectura(SeguridadQueryDBContext context) : base(context)
    {
    }
}
