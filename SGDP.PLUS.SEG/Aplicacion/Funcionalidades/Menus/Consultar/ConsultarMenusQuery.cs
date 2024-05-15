using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

public record struct ConsultarMenusQuery(
    GetEntityQuery Query,
    Guid AplicacionId, 
    Guid? ModuloId) : IRequest<DataViewModel<ConsultarMenusResponse>>;