using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

public record struct ActivarInactivarPerfilCommand(Guid PerfilId) : IRequest<ActivarInactivarPerfilResponse>;
