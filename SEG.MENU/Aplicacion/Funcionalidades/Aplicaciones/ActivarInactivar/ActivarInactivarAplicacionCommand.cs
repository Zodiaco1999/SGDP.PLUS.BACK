using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

public record struct ActivarInactivarAplicacionCommand(Guid AplicacionId) : IRequest<ActivarInactivarAplicacionResponse>;