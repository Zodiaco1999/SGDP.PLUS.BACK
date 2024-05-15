using MediatR;
using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

public record struct ConsultarPerfilMenusQuery(
    GetEntityQuery Query,
    Guid PerfilId,
    Guid? ModuloId) : IRequest<DataViewModel<ConsultarPerfilMenusResponse>>;
