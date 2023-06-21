using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

public class EditarUsuariosFotosCommandHandler : IRequestHandler<EditarUsuariosFotosCommand, EditarUsuariosFotosResponse>
{
    private readonly IGestionUsuariosFotos _gestionUsuariosFotos;
    public EditarUsuariosFotosCommandHandler(IGestionUsuariosFotos gestionUsuariosFotos) => _gestionUsuariosFotos = gestionUsuariosFotos;

    public async Task<EditarUsuariosFotosResponse> Handle(EditarUsuariosFotosCommand request, CancellationToken cancellationToken)
    {
        EditarUsuariosFotosResponse result = await _gestionUsuariosFotos.ActualizarUsuariosFotos(request);

        return result;
    }
}