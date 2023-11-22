using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ActivarInactivar;

public record struct ActivarInactivarTipoPersonaCommand(Guid TipoPersonaId) : IRequest<ActivarInactivarTipoPersonaResponse>;