using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Interfaces;
using SEG.MENU.Dominio.Entidades;
using System.Reflection;

namespace SEG.MENU.Infraestructura.Context;

public class SeguridadCommandDBContext : DbContext, ISeguridadCommandDBContext
{
    public SeguridadCommandDBContext(DbContextOptions<SeguridadCommandDBContext> options) : base(options)
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
