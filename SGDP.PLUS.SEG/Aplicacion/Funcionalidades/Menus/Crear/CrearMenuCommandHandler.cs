using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Crear;

public class CrearMenuCommandHandler : IRequestHandler<CrearMenuCommand, CrearMenuResponse>
{
    private readonly IGestionMenus _gestionMenus;
    public CrearMenuCommandHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;

    public async Task<CrearMenuResponse> Handle(CrearMenuCommand request, CancellationToken cancellationToken)
    {
        CrearMenuResponse result = await _gestionMenus.CrearMenu(request);

        return result;
    }
}