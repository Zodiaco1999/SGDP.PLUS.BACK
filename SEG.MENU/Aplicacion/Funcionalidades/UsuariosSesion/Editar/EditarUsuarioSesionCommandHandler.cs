using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Editar;

public class EditarUsuarioSesionCommandHandler : IRequestHandler<EditarUsuarioSesionCommand, EditarUsuarioSesionResponse>
{
    private readonly IGestionUsuariosSesion _gestionUsuariosSesion;
    public EditarUsuarioSesionCommandHandler(IGestionUsuariosSesion gestionUsuariosSesion) => _gestionUsuariosSesion = gestionUsuariosSesion;

    public async Task<EditarUsuarioSesionResponse> Handle(EditarUsuarioSesionCommand request, CancellationToken cancellationToken)
    {
        EditarUsuarioSesionResponse result = await _gestionUsuariosSesion.EditarUsuarioSesion(request);

        return result;
    }
}