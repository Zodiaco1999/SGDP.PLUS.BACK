﻿using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Repositorio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Repositorio;
using SGDP.PLUS.MAESTROS.Infraestructura.UnidadTrabajo;

namespace SGDP.PLUS.MAESTROS;

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

        // TipoPersona
        services.AddScoped<IGestionTipoPersonas, GestionTipoPersonas>();
        services.AddScoped<ITipoPersonaRepositorioLectura, TipoPersonaRepositorioLectura>();
        services.AddScoped<ITipoPersonaRepositorioEscritura, TipoPersonaRepositorioEscritura>();

        // TipoDocumento
        services.AddScoped<IGestionTipoDocumentos, GestionTipoDocumentos>();
        services.AddScoped<ITipoDocumentoRepositorioLectura, TipoDocumentoRepositorioLectura>();
        services.AddScoped<ITipoDocumentoRepositorioEscritura, TipoDocumentoRepositorioEscritura>();

        // Pais
        services.AddScoped<IGestionPaises, GestionPaises>();
        services.AddScoped<IPaisRepositorioLectura, PaisRepositorioLectura>();
        services.AddScoped<IPaisRepositorioEscritura, PaisRepositorioEscritura>();

        // Departamento
        services.AddScoped<IGestionDepartamentos, GestionDepartamentos>();
        services.AddScoped<IDepartamentoRepositorioLectura, DepartamentoRepositorioLectura>();
        services.AddScoped<IDepartamentoRepositorioEscritura, DepartamentoRepositorioEscritura>();

        //Ciudad
        services.AddScoped<IGestionCiudades, GestionCiudades>();
        services.AddScoped<ICiudadRepositorioLectura, CiudadRepositorioLectura>();
        services.AddScoped<ICiudadRepositorioEscritura, CiudadRepositorioEscritura>();

        //Cargo
        services.AddScoped<IGestionCargos, GestionCargos>();
        services.AddScoped<ICargoRepositorioLectura, CargoRepositorioLectura>();
        services.AddScoped<ICargoRepositorioEscritura, CargoRepositorioEscritura>();

        return services;

    }
}

