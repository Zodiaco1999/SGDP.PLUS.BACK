using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.ConsultarPorId;

public record struct ConsultarMenuPorIdQuery(Guid menuId) : IRequest<ConsultarMenuPorIdResponse>;