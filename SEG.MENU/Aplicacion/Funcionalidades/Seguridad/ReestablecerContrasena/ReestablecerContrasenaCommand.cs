using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.ReestablecerContrasena;

public record struct ReestablecerContrasenaCommand(string Email,
                                                   string PasswordNueva,
                                                   string PasswordConfirmar,
                                                   string Token) : IRequest<ReestablecerContrasenaResponse>;

