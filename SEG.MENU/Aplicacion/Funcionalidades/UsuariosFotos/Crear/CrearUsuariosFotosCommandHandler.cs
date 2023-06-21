using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Crear;

public class CrearUsuariosFotosCommandHandler : IRequestHandler<CrearUsuariosFotosCommand, CrearUsuariosFotosResponse>
{
    private readonly IGestionUsuariosFotos _gestionUsuariosFotos;
    public CrearUsuariosFotosCommandHandler(IGestionUsuariosFotos gestionUsuariosFotos) => _gestionUsuariosFotos = gestionUsuariosFotos;

    public async Task<CrearUsuariosFotosResponse> Handle(CrearUsuariosFotosCommand request, CancellationToken cancellationToken)
    {
        CrearUsuariosFotosResponse result = await _gestionUsuariosFotos.CrearUsuariosFotos(request);

        return result;
    }
}