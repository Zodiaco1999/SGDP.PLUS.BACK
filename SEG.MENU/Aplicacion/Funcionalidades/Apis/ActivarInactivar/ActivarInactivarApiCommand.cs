using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.ActivarInactivar;

public record struct ActivarInactivarApiCommand(Guid ApiId) : IRequest;