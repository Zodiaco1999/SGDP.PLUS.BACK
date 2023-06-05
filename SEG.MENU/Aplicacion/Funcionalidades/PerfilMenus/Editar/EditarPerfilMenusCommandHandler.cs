using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Editar;

public class EditarPerfilMenusCommandHandler : IRequestHandler<EditarPerfilMenusCommand, EditarPerfilMenusResponse>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;
    public EditarPerfilMenusCommandHandler(IGestionPerfilMenus gestionPerfilMenus) => _gestionPerfilMenus = gestionPerfilMenus;

    public async Task<EditarPerfilMenusResponse> Handle(EditarPerfilMenusCommand request, CancellationToken cancellationToken)
    {
        EditarPerfilMenusResponse result = await _gestionPerfilMenus.ActualizarPerfilMenu(request!);

        return result;
    }
}
