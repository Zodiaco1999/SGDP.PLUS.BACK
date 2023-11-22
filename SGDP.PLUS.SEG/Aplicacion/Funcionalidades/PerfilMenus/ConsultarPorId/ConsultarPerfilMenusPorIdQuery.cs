using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public record struct ConsultarPerfilMenusPorIdQuery(Guid PerfilId) : IRequest<IEnumerable<ConsultarPerfilMenusPorIdResponse>>;
