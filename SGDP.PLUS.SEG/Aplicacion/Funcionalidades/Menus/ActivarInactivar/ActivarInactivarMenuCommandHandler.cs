using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ActivarInactivar;

public class ActivarInactivarMenuCommandHandler : IRequestHandler<ActivarInactivarMenuCommand, ActivarInactivarMenuResponse>
{
    private readonly IGestionMenus _gestionMenus;
    public ActivarInactivarMenuCommandHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;

    public async Task<ActivarInactivarMenuResponse> Handle(ActivarInactivarMenuCommand request, CancellationToken cancellationToken)
    {
        var result = await _gestionMenus.ActivarInactivarMenu(request.menuId);

        return result;
    }
}