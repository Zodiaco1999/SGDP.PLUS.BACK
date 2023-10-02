using RTools_NTS.Util;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContraseña;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.EnviarCorreoContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Login;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.ReestablecerContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Refresh;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

public interface IGestionAutenticacion
{
    Task<LoginResponse> Login(LoginCommand loginDto);
    Task<RefreshResponse> Refresh(RefreshCommand refreshDto);
    Task Logout();
    Task<CambiarContrasenaResponse> CambiarContraseña(CambiarContrasenaCommand registroDto);
    Task<EnviarCorreoContrasenaResponse> EnviarCorreoContrasena(EnviarCorreoContrasenaCommand registroDto);
    Task<ReestablecerContrasenaResponse> ReestablecerContrasena(ReestablecerContrasenaCommand registroDto);
}

