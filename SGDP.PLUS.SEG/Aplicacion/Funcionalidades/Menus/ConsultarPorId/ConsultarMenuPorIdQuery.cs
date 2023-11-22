using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarPorId;

public record struct ConsultarMenuPorIdQuery(Guid menuId) : IRequest<ConsultarMenuPorIdResponse>;