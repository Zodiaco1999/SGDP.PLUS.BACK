using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Crear;

public class CrearUsuarioFotoCommandHandler : IRequestHandler<CrearUsuarioFotoCommand, CrearUsuarioFotoResponse>
{
    private readonly IGestionUsuariosFotos _gestionUsuariosFotos;
    public CrearUsuarioFotoCommandHandler(IGestionUsuariosFotos gestionUsuariosFotos) => _gestionUsuariosFotos = gestionUsuariosFotos;

    public async Task<CrearUsuarioFotoResponse> Handle(CrearUsuarioFotoCommand request, CancellationToken cancellationToken)
    {
        CrearUsuarioFotoResponse result = await _gestionUsuariosFotos.CrearUsuarioFoto(request);

        return result;
    }
}