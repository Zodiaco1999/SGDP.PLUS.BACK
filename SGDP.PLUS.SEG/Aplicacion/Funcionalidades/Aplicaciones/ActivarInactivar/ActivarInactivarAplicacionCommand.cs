using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

public record struct ActivarInactivarAplicacionCommand(Guid AplicacionId) : IRequest<ActivarInactivarAplicacionResponse>;