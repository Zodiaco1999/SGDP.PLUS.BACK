using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ConsultarPorId;

public record struct ConsultarPaisPorIdQuery(Guid PaisId) : IRequest<ConsultarPaisPorIdResponse>;