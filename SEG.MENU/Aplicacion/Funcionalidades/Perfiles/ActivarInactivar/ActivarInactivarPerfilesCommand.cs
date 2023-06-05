using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

public record struct ActivarInactivarPerfilesCommand(Guid PerfilId) : IRequest<ActivarInactivarPerfilesResponse>;
