using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public class ConsultarPerfilMenuPorIdQueryHandler : IRequestHandler<ConsultarPerfilMenuPorIdQuery, ConsultarPerfilMenuPorIdResponse>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public ConsultarPerfilMenuPorIdQueryHandler(IGestionPerfilMenus gestionPerfilMenus)
    {
        _gestionPerfilMenus = gestionPerfilMenus;
    }

    public async Task<ConsultarPerfilMenuPorIdResponse> Handle(ConsultarPerfilMenuPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarPerfilMenuPorIdResponse res = await _gestionPerfilMenus.ConsultarPerfilMenu(request.PerfilId);

        return res;
    }
}