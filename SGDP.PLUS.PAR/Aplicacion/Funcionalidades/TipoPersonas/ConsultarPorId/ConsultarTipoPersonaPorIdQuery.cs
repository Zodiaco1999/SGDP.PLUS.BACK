using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ConsultarPorId;

public record struct ConsultarTipoPersonaPorIdQuery(Guid TipoPersonaId) : IRequest<ConsultarTipoPersonaPorIdResponse>;