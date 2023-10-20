using Ardalis.GuardClauses;
using RTools_NTS.Util;
using SGDP.PLUS.Comun.ContextAccesor;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContraseña;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.EnviarCorreoContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Login;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.RestablecerContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Refresh;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.Entidades;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.JWT;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Repositorio;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Repositorio;
using SGDP.PLUS.SEG.Dominio.Entidades;
using SGDP.PLUS.SEG.Infraestructura.UnidadTrabajo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

public class GestionAutenticacion : BaseAppService, IGestionAutenticacion
{
    private readonly IUsuarioRepositorioLectura _usuarioRepositorioLectura;
    private readonly IUsuarioRepositorioEscritura _usuarioRepositorioEscritura;
    private readonly IUsuarioSesionRepositorioLectura _usuarioSesionLectura;
    private readonly IUsuarioSesionRepositorioEscritura _usuarioSesionEscritura;
    private readonly IUsuarioSesionLogRepositorioEscritura _usuarioSesionLogEscritura;
    private readonly IUnitOfWorkSegEscritura _unitOfWork;
    private readonly IContextAccessor _contextAccessor;
    private readonly IConfiguration _configuration;
    private readonly ParametrosSEG _parametrosSEG;
    private readonly SegMD5 _segMD5;
    private readonly IJwtFactory _jwtFactory;

    public GestionAutenticacion(
        IUsuarioRepositorioLectura usuarioRepositorioLectura,
        IUsuarioRepositorioEscritura usuarioRepositorioEscritura,
        IUsuarioSesionRepositorioLectura usuarioSesionLectura,
        IUsuarioSesionRepositorioEscritura usuarioSesionEscritura,
        IUsuarioSesionLogRepositorioEscritura usuarioSesionLogEscritura,
        IUnitOfWorkSegEscritura unitOfWork,
        IJwtFactory jwtFactory,
        IConfiguration configuration,
        IContextAccessor contextAccessor,
        ILoggerFactory loggerFactory
        ) : base(contextAccessor, loggerFactory)
    {
        _usuarioRepositorioLectura = usuarioRepositorioLectura;
        _usuarioRepositorioEscritura = usuarioRepositorioEscritura;
        _usuarioSesionLectura = usuarioSesionLectura;
        _usuarioSesionEscritura = usuarioSesionEscritura;
        _usuarioSesionLogEscritura = usuarioSesionLogEscritura;
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _contextAccessor = contextAccessor;
        _parametrosSEG = _configuration.GetSection("ParametrosSeg").Get<ParametrosSEG>()!;
        _segMD5 = new SegMD5();
        _jwtFactory = jwtFactory;
    }

    public async Task<LoginResponse> Login(LoginCommand loginDto)
    {
        string? msgValidacion = null;

        var usuario = await _usuarioRepositorioLectura
            .Query(u => !u.Eliminado && u.UsuarioId.ToLower().Trim() == loginDto.UsuarioId.ToLower().Trim())
            .FirstOrDefaultAsync() ?? throw new ValidationException("Usuario inexistente, verifique los datos");

        if (!usuario.Activo)
            msgValidacion = "Usuario inactivo";

        var totalSegundosFinBloqueo = usuario.FechaBloqueo == null ? 0 : usuario.FechaBloqueo.GetValueOrDefault().AddMinutes(_parametrosSEG.TiempoBloqueo).Subtract(DateTime.Now).TotalSeconds;

        if (usuario.AccesosFallidos >= _parametrosSEG.AccesosFallidos && totalSegundosFinBloqueo > 0)
            msgValidacion = $"Usuario bloqueado temporalmente. Intente de nuevo en {Math.Round(totalSegundosFinBloqueo / 60, MidpointRounding.AwayFromZero)} minutos";
        else
        {
            if (string.IsNullOrEmpty(loginDto.Contrasena) && loginDto.TokenRefresh != null)
            {
                var tokenRefreshHash = _segMD5.GetMd5Hash(loginDto.TokenRefresh);

                var sessionIdHash = _segMD5.GetMd5Hash(loginDto.TokenId!);

                var usuarioSesionValido = await _usuarioSesionLectura.Query(q => q.UsuarioId == loginDto.UsuarioId && q.SesionId == sessionIdHash && q.TokenActualizacion == tokenRefreshHash).FirstOrDefaultAsync();

                if (usuarioSesionValido == null)
                {
                    msgValidacion = $"Token de actualización no valido";
                }
            }
            else if (!HashCustom.CheckHash(loginDto.Contrasena!, usuario.Contrasena, usuario.Salt)) // && _parametrosSEG.ValidarContrasena
            {
                usuario.AccesosFallidos = (short)(usuario.AccesosFallidos.GetValueOrDefault() + 1);
                msgValidacion = $"Contraseña no valida. Verifique los datos. {_parametrosSEG.AccesosFallidos - usuario.AccesosFallidos} intentos mas y se bloqueara temporalmente el usuario.";
                if (usuario.AccesosFallidos.GetValueOrDefault() >= _parametrosSEG.AccesosFallidos)
                {
                    usuario.FechaBloqueo = DateTime.Now;
                    msgValidacion = $"Se excedio el número de intentos permitido, por seguridad la cuenta se ha bloqueado temporalmente. Intente de nuevo en {_parametrosSEG.TiempoBloqueo} minutos";
                }
            }
            else
            {
                usuario.AccesosFallidos = null;
                usuario.FechaBloqueo = null;
            }
        }

        if (!string.IsNullOrEmpty(msgValidacion))
        {
            await _unitOfWork.SaveChangesAsync();

            throw new ValidationException(msgValidacion);
        }

        string sesionId = Guid.NewGuid().ToString();
        string refreshToken = Guid.NewGuid().ToString();

        var usuarioSesion = new UsuarioSesion()
        {
            UsuarioId = usuario.UsuarioId,
            SesionId = _segMD5.GetMd5Hash(sesionId),
            InicioSesion = DateTime.Now,
            IpCliente = _contextAccessor.ClientIP,
            TokenActualizacion = _segMD5.GetMd5Hash(refreshToken)
        };
        usuario.UsuarioSesions.Add(usuarioSesion);

        var usuarioSesionLog = new UsuarioSesionLog()
        {
            LogId = Guid.NewGuid(),
            UsuarioId = usuario.UsuarioId,
            SesionId = _segMD5.GetMd5Hash(sesionId),
            Fecha = DateTime.Now,
            IpCliente = _contextAccessor.ClientIP,
            DataSesion = _contextAccessor.Headers,
            Accion = "Inicio de Sesión",
            MsgValidacion = msgValidacion
        };

        _usuarioSesionLogEscritura.Insert(usuarioSesionLog);
        await _unitOfWork.SaveChangesAsync();

        return new LoginResponse(
            new UserLogin(usuario.UsuarioId, usuario.Email, usuario.PrimerNombre, usuario.PrimerApellido, usuario.Genero),
            BuildToken(usuario, sesionId, refreshToken),
            sesionId,
            true);
    }

    private string BuildToken(Usuario user, string sesionId, string tokenRefresh)
    {
        var claimsIdentity = GenerateClaimsIdentity(user, sesionId);

        return _jwtFactory.GenerateEncodedToken(user.UsuarioId, claimsIdentity, tokenRefresh);
    }

    private ClaimsIdentity GenerateClaimsIdentity(Usuario user, string sesionId)
    {
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.NameId, user.UsuarioId));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, user.UsuarioId));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Actort, $"{user.PrimerNombre} {user.PrimerApellido}"));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, sesionId));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Gender, user.Genero));

        return claimsIdentity;
    }

    public async Task<RefreshResponse> Refresh(RefreshCommand refreshDto)
    {
        string jwt = refreshDto.Jwt.Replace("Bearer", "").Trim();
        var tokenDecode = _jwtFactory.DecodeToken(jwt);

        var login = new LoginCommand(
            tokenDecode.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.NameId)!.Value,
            "",
            null,
            refreshDto.TokenRefresh,
            tokenDecode.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.Jti)?.Value);

        var sessionId = _segMD5.GetMd5Hash(login.TokenId!);

        var usuarioSesion = await _usuarioSesionLectura
            .Query(q => q.UsuarioId == login.UsuarioId && q.SesionId == sessionId)
            .Include(i => i.Usuario)
            .FirstOrDefaultAsync();

        if ((usuarioSesion != null) || (!_segMD5.VerifyMd5Hash(refreshDto.TokenRefresh, usuarioSesion.TokenActualizacion)) || (!usuarioSesion.Usuario.Activo || usuarioSesion.Usuario.FechaActualizacionContrasena > usuarioSesion.InicioSesion))
        {
            if (usuarioSesion != null)
            {
                usuarioSesion.Eliminado = true;

                await _unitOfWork.SaveChangesAsync();
            }

            if (usuarioSesion == null)
            {
                throw new ValidationException("Token no valido");
            }

            if (!_segMD5.VerifyMd5Hash(refreshDto.TokenRefresh, usuarioSesion.TokenActualizacion))
            {
                throw new ValidationException("Token no valido");
            }

            if (!usuarioSesion.Usuario.Activo)
            {
                throw new ValidationException("Usuario inactivo");
            }

            if (usuarioSesion.Usuario.FechaActualizacionContrasena > usuarioSesion.InicioSesion)
            {
                throw new ValidationException("Requiere autenticación");
            }

        }

        var loginResponse = await Login(login);

        return new RefreshResponse(
            loginResponse.User,
            loginResponse.Jwt,
            loginResponse.TokenSession,
            loginResponse.Valid);
    }

    public async Task Logout()
    {
        var sesionId = _segMD5.GetMd5Hash(_contextAccessor.SessionId);

        var usuarioSesion = await _usuarioSesionLectura.Query(q => q.UsuarioId == _contextAccessor.UserName && q.SesionId == sesionId).FirstOrDefaultAsync();

        if (usuarioSesion != null)
        {
            usuarioSesion.Eliminado = true;
        }

        var usuarioSesionLog = new UsuarioSesionLog()
        {
            LogId = Guid.NewGuid(),
            UsuarioId = _contextAccessor.UserName,
            SesionId = sesionId,
            Fecha = DateTime.Now,
            IpCliente = _contextAccessor.ClientIP,
            DataSesion = _contextAccessor.Headers,
            Accion = "Cierre de Sesión"
        };

        _usuarioSesionLogEscritura.Insert(usuarioSesionLog);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<CambiarContrasenaResponse> CambiarContraseña(CambiarContrasenaCommand registroDto)
    {
        var user = await _usuarioRepositorioEscritura
            .Query(x => x.UsuarioId == ContextAccessor.UserId)
            .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Usuario), "El usuario no existe");

        if (!HashCustom.CheckHash(registroDto.PasswordActual, user.Contrasena, user.Salt))
            throw new Exception("Contraseña actual invalida");
        else
        {
            var hash = HashCustom.Hash(registroDto.PasswordNueva);
            user.Contrasena = hash.Password;
            user.Salt = hash.Salt;

            _usuarioRepositorioEscritura.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new CambiarContrasenaResponse("Contraseña cambiada correctamente");
        }
    }

    public async Task<EnviarCorreoContrasenaResponse> EnviarCorreoContrasena(EnviarCorreoContrasenaCommand registroDto)
    {
        var user = await _usuarioRepositorioEscritura
                       .Query(q => q.Email == registroDto.Email)
                       .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Usuario), "No se encontró el usuario");

        var correo = new Correo()
        {
            MailBox = _configuration.GetSection("MailData:mailBox").Value!,
            Addressee = registroDto.Email
        };

        string token = CrearTokenRandom();
        string link = $"{_configuration.GetValue<string>("AngularClient:ResetPasswordUrl")}/{registroDto.Email}/{token}";

        GraphClientCustom client = new();
        _configuration.Bind("GraphClient", client);

        try
        {
            await correo.SendResetPasswordEmail(link, client);
        }
        catch (Exception ex)
        {
            throw new Exception($"Correo no enviado: {ex.Message}");
        }

        user.Token = token;
        user.FechaExpiracionToken = DateTime.Now.AddMinutes(_configuration.GetValue<double>("ResetPassword:timeExpiration"));
        _usuarioRepositorioEscritura.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return new EnviarCorreoContrasenaResponse("Correo enviado correctamente");
    }

    public async Task<RestablecerContrasenaResponse> RestablecerContrasena(RestablecerContrasenaCommand registroDto)
    {
        var user = await _usuarioRepositorioLectura
                        .Query(q => q.Email == registroDto.Email)
                        .FirstOrDefaultAsync() ?? throw new NotFoundException(nameof(Usuario), "No se encontró el usuario, email invalido");

        if (user.Token != registroDto.Token || user.FechaExpiracionToken < DateTime.Now)
            throw new Exception("El tiempo para restablecer la contraseña caducó, por favor realice el proceso nuevamente.");

        if (!registroDto.PasswordNueva.Equals(registroDto.PasswordConfirmacion))
            throw new ValidationException("Las contraseñas no coinciden");

        var hash = HashCustom.Hash(registroDto.PasswordNueva);
        user.Contrasena = hash.Password;
        user.Salt = hash.Salt;
        user.Token = null;
        user.FechaExpiracionToken = null;

        _usuarioRepositorioEscritura.Update(user);
        await _unitOfWork.SaveChangesAsync();

        return new RestablecerContrasenaResponse("Contraseña reestablecida correctamente");
    }

    private string CrearTokenRandom()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }

}

