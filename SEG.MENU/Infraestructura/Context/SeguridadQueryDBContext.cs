using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Interfaces;
using SEG.MENU.Dominio.Entidades;
using System.Reflection;

namespace SEG.MENU.Infraestructura.Context;

public class SeguridadQueryDBContext : DbContext, ISeguridadQueryDBContext
{
    public SeguridadQueryDBContext(DbContextOptions<SeguridadQueryDBContext> options) : base(options)
    {
    }

    public DbSet<Aplication> Aplicaciones { get; set; }
    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<Perfil> Perfiles { get; set; }
    public DbSet<PerfilMenu> PerfilMenus { get; set; }
    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
