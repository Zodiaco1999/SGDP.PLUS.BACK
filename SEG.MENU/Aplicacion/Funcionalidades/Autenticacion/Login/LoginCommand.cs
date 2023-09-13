using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Login;

public record struct LoginCommand(
    string UsuarioId,
    string Contrasena,
    string? AppId,
    string? TokenRefresh,
    string? TokenId) : IRequest<LoginResponse>;
