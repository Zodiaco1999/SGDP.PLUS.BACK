using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;

public class ConsultarMenusQueryHandler : IRequestHandler<ConsultarMenusQuery, DataViewModel<ConsultarMenusResponse>>
{
    private readonly IGestionMenus _gestionMenus;
    public ConsultarMenusQueryHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;

    public async Task<DataViewModel<ConsultarMenusResponse>> Handle(ConsultarMenusQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarMenusResponse> result = await _gestionMenus.ConsultarMenus(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}