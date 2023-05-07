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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
