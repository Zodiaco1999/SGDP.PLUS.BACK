using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public record struct ConsultarPerfilMenuPorIdQuery(Guid PerfilId) : IRequest<ConsultarPerfilMenuPorIdResponse>;
