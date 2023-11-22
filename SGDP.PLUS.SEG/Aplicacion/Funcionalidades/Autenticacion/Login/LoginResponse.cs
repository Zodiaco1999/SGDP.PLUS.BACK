using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Login;
public record struct LoginResponse(
    UserLogin User,
    string Jwt,
    string TokenSession,
    bool Valid);