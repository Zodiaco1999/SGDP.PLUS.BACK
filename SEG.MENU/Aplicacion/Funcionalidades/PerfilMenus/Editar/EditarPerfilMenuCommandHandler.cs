using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Editar;

public class EditarPerfilMenuCommandHandler : IRequestHandler<EditarPerfilMenuCommand, EditarPerfilMenuResponse>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;
    public EditarPerfilMenuCommandHandler(IGestionPerfilMenus gestionPerfilMenus) => _gestionPerfilMenus = gestionPerfilMenus;

    public async Task<EditarPerfilMenuResponse> Handle(EditarPerfilMenuCommand request, CancellationToken cancellationToken)
    {
        EditarPerfilMenuResponse result = await _gestionPerfilMenus.EditarPerfilMenu(request!);

        return result;
    }
}
