using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Refresh;

public record struct RefreshCommand(string TokenRefresh, string Jwt) : IRequest<RefreshResponse>;
