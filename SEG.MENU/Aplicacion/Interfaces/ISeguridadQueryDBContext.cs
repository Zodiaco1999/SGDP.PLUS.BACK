using Microsoft.EntityFrameworkCore;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Interfaces
{
    public interface ISeguridadQueryDBContext
    {
        DbSet<Aplication> Aplicaciones { get;}
    }
}
