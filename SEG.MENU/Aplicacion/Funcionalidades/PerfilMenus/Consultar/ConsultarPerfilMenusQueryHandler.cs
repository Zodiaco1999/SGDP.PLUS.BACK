using MediatR;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

public class ConsultarPerfilMenusQueryHandler : IRequestHandler<ConsultarPerfilMenusQuery, DataViewModel<ConsultarPerfilMenusResponse>>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public ConsultarPerfilMenusQueryHandler(IGestionPerfilMenus gestionPerfilMenus)
    {
        _gestionPerfilMenus = gestionPerfilMenus;
    }
    
    public async Task<DataViewModel<ConsultarPerfilMenusResponse>> Handle(ConsultarPerfilMenusQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarPerfilMenusResponse> res = await _gestionPerfilMenus.ConsultarPerfilMenus(request.textoBusqueda, request.pagina, request.registrosPorPagina);
        return res;
    }
}
