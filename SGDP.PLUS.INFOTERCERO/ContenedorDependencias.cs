using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.LogicaNegocio;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Repositorio;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.InfoBasicas.Repositorio;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Repositorio;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.LogicaNegocio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT;
using System.Text;

namespace SGDP.PLUS.INFOTERCERO;

public static class ContenedorDependencias
{
    public static IServiceCollection AddAplicacionesServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        #region Configuración unidades de trabajo

        services.AddDbContext<IUnitOfWorkInfoTerceroEscritura, UnitOfWorkInfoTerceroEscritura>(options => options.UseSqlServer(configuration.GetConnectionString("Escritura")));
        services.AddDbContext<IUnitOfWorkInfoTerceroLectura, UnitOfWorkInfoTerceroLectura>(options => options.UseSqlServer(configuration.GetConnectionString("Lectura")));

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

        #region Configuracion de Swagger

        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor inserte el jwt despues de la palabra bearer de esta forma \"<strong>bearer {JWT}</strong>\"",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        #endregion
        // Http Client
        services.AddScoped(sp => new HttpClient());

        services.AddScoped<IGestionInformaApi, GestionInformaApi>();

        // InfoBasica
        services.AddScoped<IInfoBasicaRepositorioEscritura, InfoBasicaRepositorioEscritura>();
        services.AddScoped<IInfoBasicaRepositorioLectura, InfoBasicaRepositorioLectura>();
        // RespuestaLaft
        services.AddScoped<IGestionRespuestaLafts, GestionRespuestaLafts>();
        services.AddScoped<IRespuestaLaftRepositorioEscritura, RespuestaLaftRepositorioEscritura>();
        services.AddScoped<IRespuestaLaftRepositorioLectura, RespuestaLaftRepositorioLectura>();
        // IlicitosRespuesta
        services.AddScoped<IGestionIlicitosRespuestas, GestionIlicitosRespuestas>();
        services.AddScoped<IIlicitosRespuestaEscritura, IlicitosRespuestaEscritura>();
        services.AddScoped<IIlicitosRespuestaLectura, IlicitosRespuestaLectura>();

        return services;
    }
}
