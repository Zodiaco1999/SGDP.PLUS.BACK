using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.ConsultarPorId;

public class ConsultarMenuPorIdQueryHandler : IRequestHandler<ConsultarMenuPorIdQuery, ConsultarMenuPorIdResponse>
{
    private readonly IGestionMenus _gestionMenus;
    public ConsultarMenuPorIdQueryHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;

    public async Task<ConsultarMenuPorIdResponse> Handle(ConsultarMenuPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarMenuPorIdResponse result = await _gestionMenus.ConsultarMenuPorId(request.menuId);

        return result;
    }
}