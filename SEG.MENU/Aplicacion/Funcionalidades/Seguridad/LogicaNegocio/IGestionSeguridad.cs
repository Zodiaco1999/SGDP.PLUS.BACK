using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Login;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;

public interface IGestionSeguridad
{
    Task<LoginResponse> Login(LoginCommand registroDto);
}

