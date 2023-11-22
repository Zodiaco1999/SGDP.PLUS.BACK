using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Editar;

public record struct EditarTipoPersonaCommand(Guid TipoPersonaId, string NombreTipo) : IRequest<EditarTipoPersonaResponse>;