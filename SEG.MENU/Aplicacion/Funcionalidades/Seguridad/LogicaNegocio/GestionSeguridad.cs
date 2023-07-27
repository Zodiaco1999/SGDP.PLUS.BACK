using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Login;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;
public class GestionSeguridad : BaseAppService, IGestionSeguridad
{
    private readonly ISeguridadRepositorioLectura _seguridadRepositorioLectura;
    private readonly IContextAccessor _contextAccesor;
    private readonly IConfiguration _configuration;

    public GestionSeguridad(
        ISeguridadRepositorioLectura seguridadLectura,
        IConfiguration configuration,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _seguridadRepositorioLectura = seguridadLectura;
        _configuration = configuration;
        _contextAccesor = contextAccessor;
    }

    public async Task<LoginResponse> Login(LoginCommand registroDto)
    {
        var user = await _seguridadRepositorioLectura
            .Query(q => q.Email == registroDto.Email)
            .FirstOrDefaultAsync();

        if (user == null || !Jwt.CheckHash(registroDto.Contrasena, user.Contrasena, user.Salt))
        {
            throw new Exception("Usuario o Contraseña incorrectos");
        }

        return new LoginResponse(CrearToken(user));
    }

    private string CrearToken(Usuario user)
    {
        List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
            };

        //Expiracion del token
        var expiration = DateTime.Now.AddHours(Convert.ToDouble(_configuration.GetSection("JWT:DuracionToken").Value));

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(_configuration.GetSection("JWT:Secreto").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}

