using MediatR;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.Consultar;

public class ConsultarMenusQueryHandler : IRequestHandler<ConsultarMenusQuery, DataViewModel<ConsultarMenusResponse>>
{
    private readonly IGestionMenus _gestionMenus;
    public ConsultarMenusQueryHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;

    public async Task<DataViewModel<ConsultarMenusResponse>> Handle(ConsultarMenusQuery request, CancellationToken cancellationToken) 
        => await _gestionMenus.ConsultarMenus(request.AplicacionId, request.ModuloId, request.TextoBusqueda, request.Pagina, request.RegistrosPorPagina);

}