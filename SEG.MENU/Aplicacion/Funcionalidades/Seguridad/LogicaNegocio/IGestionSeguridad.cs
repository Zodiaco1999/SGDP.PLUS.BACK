using RTools_NTS.Util;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContraseña;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.EnviarCorreoContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Login;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.ReestablecerContrasena;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;

public interface IGestionSeguridad
{
    Task<LoginResponse> Login(LoginCommand registroDto);
    Task<CambiarContrasenaResponse> CambiarContraseña(CambiarContrasenaCommand registroDto);
    Task<EnviarCorreoContrasenaResponse> EnviarCorreoContrasena(EnviarCorreoContrasenaCommand registroDto);
    Task<ReestablecerContrasenaResponse> ReestablecerContrasena(ReestablecerContrasenaCommand registroDto);
}

