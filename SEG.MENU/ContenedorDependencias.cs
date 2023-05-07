using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Interfaces;
using SEG.MENU.Infraestructura.Context;

namespace SEG.MENU;

public static class ContenedorDependencias
{
    public static IServiceCollection AddAplicacionesServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        services.AddDbContext<SeguridadCommandDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Escritura")));
        services.AddDbContext<SeguridadQueryDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("Lectura")));

        services.AddScoped<ISeguridadCommandDBContext>(sp => sp.GetRequiredService<SeguridadCommandDBContext>());
        services.AddScoped<ISeguridadQueryDBContext>(sp => sp.GetRequiredService<ISeguridadQueryDBContext>());

        return services;
    }
}
