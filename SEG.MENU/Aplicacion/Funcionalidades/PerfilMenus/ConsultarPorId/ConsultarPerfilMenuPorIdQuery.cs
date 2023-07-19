using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public record struct ConsultarPerfilMenuPorIdQuery(Guid PerfilId) : IRequest<ConsultarPerfilMenuPorIdResponse>;
