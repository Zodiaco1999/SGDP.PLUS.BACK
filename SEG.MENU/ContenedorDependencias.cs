﻿using Microsoft.EntityFrameworkCore;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Repositorio;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;
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
        services.AddScoped<ISeguridadQueryDBContext>(sp => sp.GetRequiredService<SeguridadQueryDBContext>());

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

        return services;
    }
}
