using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SEG.Comun.ContextAccesor;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Repositorio;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Repositorio;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
using SEG.MENU.Infraestructura.UnidadTrabajo;

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
        //UsuarioPerfil
        services.AddScoped<IGestionUsuarioPerfil, GestionUsuarioPerfil>();
        services.AddScoped<IUsuarioPerfilRepositorioLectura, UsuarioPerfilRepositorioLectura>();
        services.AddScoped<IUsuarioPerfilRepositorioEscritura, UsuarioPerfilRepositorioEscritura>();
        //UsuarioFoto
        services.AddScoped<IGestionUsuariosFotos, GestionUsuariosFotos>();
        services.AddScoped<IUsuarioFotoRepositorioLectura, UsuarioFotoRepositorioLectura>();
        services.AddScoped<IUsuarioFotoRepositorioEscritura, UsuarioFotoRepositorioEscritura>();
        //Usuario
        services.AddScoped<IGestionUsuarios, GestionUsuarios>();
        services.AddScoped<IUsuarioRepositorioLectura, UsuarioRepositorioLectura>();
        services.AddScoped<IUsuarioRepositorioEscritura, UsuarioRepositorioEscritura>();
       
        return services;
    }
}
