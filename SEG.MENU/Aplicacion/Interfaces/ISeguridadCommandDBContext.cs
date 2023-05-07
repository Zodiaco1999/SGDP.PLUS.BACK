using Microsoft.EntityFrameworkCore;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Interfaces
{
    public interface ISeguridadCommandDBContext
    {
        DbSet<Aplication> Aplicaciones { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
