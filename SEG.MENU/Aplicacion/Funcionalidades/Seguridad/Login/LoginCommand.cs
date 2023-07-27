using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Login;
public record struct LoginCommand(
                        string Email,
                        string? Contrasena) : IRequest<LoginResponse>;