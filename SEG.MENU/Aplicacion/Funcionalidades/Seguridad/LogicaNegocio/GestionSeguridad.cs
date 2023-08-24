
using Ardalis.GuardClauses;
using Microsoft.IdentityModel.Tokens;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContraseña;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.EnviarCorreoContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Login;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.ReestablecerContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;
public class GestionSeguridad : BaseAppService, IGestionSeguridad
{
    private readonly ISeguridadRepositorioLectura _seguridadRepositorioLectura;
    private readonly ISeguridadRepositorioEscritura _seguridadRepositorioEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccesor;
    private readonly IConfiguration _configuration;

    public GestionSeguridad(
        ISeguridadRepositorioLectura seguridadLectura,
        ISeguridadRepositorioEscritura seguridadEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IConfiguration configuration,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _seguridadRepositorioLectura = seguridadLectura;
        _seguridadRepositorioEscritura = seguridadEscritura;
        _unitOfWork = unitOfWork;
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

    public async Task<CambiarContrasenaResponse> CambiarContraseña(CambiarContrasenaCommand registroDto)
    {
        var user = await _seguridadRepositorioEscritura
            .Query(x => x.Email == registroDto.Email)
            .FirstOrDefaultAsync();

        if (user == null)
            throw new Exception("El email no existe");
        else if (!Jwt.CheckHash(registroDto.PasswordActual, user.Contrasena, user.Salt))
            throw new Exception("Contraseña actual invalida");
        else
        {
            var hash = Jwt.Hash(registroDto.PasswordNueva);
            user.Contrasena = hash.Password;
            user.Salt = hash.Salt;

            _seguridadRepositorioEscritura.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new CambiarContrasenaResponse("Contraseña cambiada correctamente");
        }
    }

    public async Task<EnviarCorreoContrasenaResponse> EnviarCorreoContrasena(EnviarCorreoContrasenaCommand registroDto)
    {
        
        var user = await _seguridadRepositorioEscritura
                       .Query(q => q.Email == registroDto.Email)
                       .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Usuario), "No se encontró el usuario");

        var correo = new Correo() 
        { 
            MailBox = _configuration.GetSection("MailData:mailBox").Value!,
            Addressee = registroDto.Email
        };

        string token = CrearTokenRandom();
        string link = $"{_configuration.GetSection("Client:url").Value}/restablecercontrasena/{registroDto.Email}/{token}";

        try
        {
            await correo.SendResetPasswordEmail(link);
        }
        catch (Exception ex)
        {
            throw new Exception($"Correo no enviado: {ex.Message}");
        }

        user.Token = token;
        user.FechaExpiracionToken = DateTime.Now.AddMinutes(_configuration.GetValue<double>("ResetPassword:timeExpiration"));
        _seguridadRepositorioEscritura.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return new EnviarCorreoContrasenaResponse("Correo enviado correctamente");
    }

    public async Task<ReestablecerContrasenaResponse> ReestablecerContrasena(ReestablecerContrasenaCommand registroDto)
    {
        await VerificarToken(registroDto.Email, registroDto.Token);
        var user = await _seguridadRepositorioLectura
                        .Query(q => q.Email == registroDto.Email)
                        .FirstOrDefaultAsync();

        var hash = Jwt.Hash(registroDto.PasswordNueva);
        user.Contrasena = hash.Password;
        user.Salt = hash.Salt;
        user.Token = null;
        user.FechaExpiracionToken = null;

        _seguridadRepositorioEscritura.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return new ReestablecerContrasenaResponse("Contraseña reestablecida correctamente");
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

    private async Task VerificarToken(string correo, string token)
    {
        var user = await _seguridadRepositorioLectura
                        .Query(q => q.Email == correo)
                        .FirstOrDefaultAsync();
        if (user == null || user.Token != token || user.FechaExpiracionToken < DateTime.Now)
            throw new Exception("El tiempo para restablecer la contraseña caducó, por favor vuelva a solicitarlo nuevamente.");
    }
    private string CrearTokenRandom()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }

}

