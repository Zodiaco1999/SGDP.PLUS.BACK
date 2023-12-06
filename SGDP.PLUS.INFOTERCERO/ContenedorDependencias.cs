using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT;
using System.Text;

namespace SGDP.PLUS.INFOTERCERO;

public static class ContenedorDependencias
{
    public static IServiceCollection AddAplicacionesServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        #region Configuración unidades de trabajo

        services.AddDbContext<UnitOfWorkInfoTerceroEscritura>(options => options.UseSqlServer(configuration.GetConnectionString("Escritura")));
        services.AddScoped<IUnitOfWorkInfoTerceroEscritura>(provider => provider.GetRequiredService<UnitOfWorkInfoTerceroEscritura>());

        services.AddDbContext<UnitOfWorkInfoTerceroLectura>(options => options.UseSqlServer(configuration.GetConnectionString("Lectura")));
        services.AddScoped<IUnitOfWorkInfoTerceroLectura>(provider => provider.GetRequiredService<UnitOfWorkInfoTerceroLectura>());

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

        services.AddScoped(sp => new HttpClient());

        // Terceros
        services.AddScoped<IGestionTerceros, GestionTerceros>();

        return services;
    }
}
