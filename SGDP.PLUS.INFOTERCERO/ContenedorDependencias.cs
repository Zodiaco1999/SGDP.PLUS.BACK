using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SGDP.PLUS.INFOTERCERO.Infraestructura.UnidadTrabajo;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
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

        return services;
    }
}
