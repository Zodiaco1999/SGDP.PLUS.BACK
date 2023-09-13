using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Refresh;

public record struct RefreshResponse(
    UserLogin User,
    string Jwt,
    string TokenSession,
    bool Valid);