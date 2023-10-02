using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Repositorio;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using System.Text;

namespace SGDP.PLUS.SEG;

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

        #region Configuración Autenticación con JWT

        var jwtOptions = configuration.GetSection(nameof(JwtOptions));

        services.Configure<JwtOptions>(options =>
        {
            options.Issuer = jwtOptions[nameof(JwtOptions.Issuer)]!;
            options.Audience = jwtOptions[nameof(JwtOptions.Audience)]!;
            options.ValidForMinutes = int.Parse(jwtOptions[nameof(JwtOptions.ValidForMinutes)]!);
            options.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["SecretKeyJWT"]!)), SecurityAlgorithms.HmacSha384);
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions[nameof(JwtOptions.Issuer)],

                    ValidateAudience = true,
                    ValidAudience = jwtOptions[nameof(JwtOptions.Audience)],

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(System.Text.Encoding.UTF8
                        .GetBytes(configuration["SecretKeyJWT"]!)),

                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

        services.AddScoped<IJwtFactory, JwtFactory>();

        #endregion

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
        // UsuarioPerfil
        services.AddScoped<IGestionUsuarioPerfil, GestionUsuarioPerfil>();
        services.AddScoped<IUsuarioPerfilRepositorioLectura, UsuarioPerfilRepositorioLectura>();
        services.AddScoped<IUsuarioPerfilRepositorioEscritura, UsuarioPerfilRepositorioEscritura>();
        // UsuarioFoto
        services.AddScoped<IGestionUsuariosFotos, GestionUsuariosFotos>();
        services.AddScoped<IUsuarioFotoRepositorioLectura, UsuarioFotoRepositorioLectura>();
        services.AddScoped<IUsuarioFotoRepositorioEscritura, UsuarioFotoRepositorioEscritura>();
        // Usuario
        services.AddScoped<IGestionUsuarios, GestionUsuarios>();
        services.AddScoped<IUsuarioRepositorioLectura, UsuarioRepositorioLectura>();
        services.AddScoped<IUsuarioRepositorioEscritura, UsuarioRepositorioEscritura>();
        // UsuarioSesion
        services.AddScoped<IGestionUsuariosSesion, GestionUsuariosSesion>();
        services.AddScoped<IUsuarioSesionRepositorioLectura, UsuarioSesionRepositorioLectura>();
        services.AddScoped<IUsuarioSesionRepositorioEscritura, UsuarioSesionRepositorioEscritura>();
        // UsuarioSesionLog
        services.AddScoped<IGestionUsuariosSesionLog, GestionUsuariosSesionLog>();
        services.AddScoped<IUsuarioSesionLogRepositorioLectura, UsuarioSesionLogRepositorioLectura>();
        services.AddScoped<IUsuarioSesionLogRepositorioEscritura, UsuarioSesionLogRepositorioEscritura>();
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
        // Autenticacion
        services.AddScoped<IGestionAutenticacion, GestionAutenticacion>();

        return services;
    }
}
