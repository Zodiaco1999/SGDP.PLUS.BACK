using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Crear;

public class CrearUsuarioSesionCommandHandler : IRequestHandler<CrearUsuarioSesionCommand, CrearUsuarioSesionResponse>
{
    private readonly IGestionUsuariosSesion _gestionUsuariosSesion;
    public CrearUsuarioSesionCommandHandler(IGestionUsuariosSesion gestionUsuariosSesion) => _gestionUsuariosSesion = gestionUsuariosSesion;

    public async Task<CrearUsuarioSesionResponse> Handle(CrearUsuarioSesionCommand request, CancellationToken cancellationToken)
    {
        return await _gestionUsuariosSesion.CrearUsuarioSesion(request);
    }
}