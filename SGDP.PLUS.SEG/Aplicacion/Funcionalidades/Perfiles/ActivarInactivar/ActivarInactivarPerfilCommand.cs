using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

public record struct ActivarInactivarPerfilCommand(Guid PerfilId) : IRequest<ActivarInactivarPerfilResponse>;
