using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.ActivarInactivar;

public record struct ActivarInactivarApiCommand(Guid ApiId) : IRequest;