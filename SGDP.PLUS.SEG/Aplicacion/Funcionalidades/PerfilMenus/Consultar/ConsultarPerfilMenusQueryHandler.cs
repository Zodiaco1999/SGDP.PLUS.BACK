using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

public class ConsultarPerfilMenusQueryHandler : IRequestHandler<ConsultarPerfilMenusQuery, DataViewModel<ConsultarPerfilMenusResponse>>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public ConsultarPerfilMenusQueryHandler(IGestionPerfilMenus gestionPerfilMenus)
    {
        _gestionPerfilMenus = gestionPerfilMenus;
    }

    public async Task<DataViewModel<ConsultarPerfilMenusResponse>> Handle(ConsultarPerfilMenusQuery request, CancellationToken cancellationToken)
        => await _gestionPerfilMenus.ConsultarPerfilMenus(request.Query, request.PerfilId, request.ModuloId);

}
