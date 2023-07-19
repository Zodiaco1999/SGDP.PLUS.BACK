using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.Editar;

public class EditarMenuCommandHandler : IRequestHandler<EditarMenuCommand, EditarMenuResponse>
{
    private readonly IGestionMenus _gestionMenus;
    public EditarMenuCommandHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;

    public async Task<EditarMenuResponse> Handle(EditarMenuCommand request, CancellationToken cancellationToken)
    {
        EditarMenuResponse result = await _gestionMenus.EditarMenu(request);

        return result;
    }
}