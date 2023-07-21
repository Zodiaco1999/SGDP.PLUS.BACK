using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;

namespace SEG.MENU;

public static class ContenedorDependencias
{
    public static IServiceCollection AddAplicacionesServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        #region Configuración unidades de trabajo

        services.AddDbContext<UnitOfWorkSegEscritura>(options => options.UseSqlServer(configuration.GetConnectionString("Escritura")));
        services.AddScoped<IUnitOfWorkSegEscritura>(provider => provider.GetRequiredService<UnitOfWorkSegEscritura>());

        services.AddDbContext<UnitOfWorkSegLectura>(options => options.UseSqlServer(configuration.GetConnectionString("Lectura")));
        services.AddScoped<IUnitOfWorkSegLectura>(provider => provider.GetRequiredService<UnitOfWorkSegLectura>());

        #endregion

        services.AddHttpContextAccessor();
        services.AddControllers();
        services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

        services.AddSingleton<IContextAccessor, ContextAccessor>();

        // Aplicacion
        services.AddScoped<IGestionAplicaciones, GestionAplicaciones>();
        services.AddScoped<IAplicationRepositorioLectura, AplicationRepositorioLectura>();
        services.AddScoped<IAplicationRepositorioEscritura, AplicationRepositorioEscritura>();
        // Perfil
        services.AddScoped<IGestionPerfiles, GestionPerfiles>();
        services.AddScoped<IPerfilRepositorioLectura, PerfilRepositorioLectura>();
        services.AddScoped<IPerfilRepositorioEscritura, PerfilRepositorioEscritura>();
        // PerfilMenu
        services.AddScoped<IGestionPerfilMenus, GestionPerfilMenus>();
        services.AddScoped<IPerfilMenuRepositorioLectura, PerfilMenuRepositorioLectura>();
        services.AddScoped<IPerfilMenuRepositorioEscritura, PerfilMenuRepositorioEscritura>();
        // Menu
        services.AddScoped<IGestionMenus, GestionMenus>();
        services.AddScoped<IMenuRepositorioLectura, MenuRepositorioLectura>();
        services.AddScoped<IMenuRepositorioEscritura, MenuRepositorioEscritura>();
        // Modulo
        services.AddScoped<IGestionModulos, GestionModulos>();
        services.AddScoped<IModuloRepositorioLectura, ModuloRepositorioLectura>();
        services.AddScoped<IModuloRepositorioEscritura, ModuloRepositorioEscritura>();
        // Api
        services.AddScoped<IGestionApis, GestionApis>();
        services.AddScoped<IApiRepositorioLectura, ApiRepositorioLectura>();
        services.AddScoped<IApiRepositorioEscritura, ApiRepositorioEscritura>();

        return services;
    }
}
