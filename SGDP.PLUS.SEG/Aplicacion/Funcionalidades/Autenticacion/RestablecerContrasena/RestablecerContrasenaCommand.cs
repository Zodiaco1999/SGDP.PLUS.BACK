using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.RestablecerContrasena;

public record struct RestablecerContrasenaCommand(
    string Email,
    string PasswordNueva,
    string PasswordConfirmacion,
    string Token) : IRequest<RestablecerContrasenaResponse>;

