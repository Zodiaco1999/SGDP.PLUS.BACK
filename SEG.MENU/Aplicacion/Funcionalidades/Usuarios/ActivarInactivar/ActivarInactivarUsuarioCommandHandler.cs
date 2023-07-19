using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.ActivarInactivar;

public class ActivarInactivarUsuariosCommandHandler : IRequestHandler<ActivarInactivarUsuarioCommand, ActivarInactivarUsuarioResponse>
{
    private readonly IGestionUsuarios _gestionUsuarios;
    public ActivarInactivarUsuariosCommandHandler(IGestionUsuarios gestionUsuarios) => _gestionUsuarios = gestionUsuarios;

    public async Task<ActivarInactivarUsuarioResponse> Handle(ActivarInactivarUsuarioCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarUsuarioResponse result = await _gestionUsuarios.ActivarInactivarUsuario(request.UsuarioId);

        return result;
    }
}