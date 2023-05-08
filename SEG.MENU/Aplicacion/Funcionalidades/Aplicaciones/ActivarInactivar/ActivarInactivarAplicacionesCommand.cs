using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

public record struct ActivarInactivarAplicacionesCommand(Guid AplicacionId) : IRequest<ActivarInactivarAplicacionesResponse>;