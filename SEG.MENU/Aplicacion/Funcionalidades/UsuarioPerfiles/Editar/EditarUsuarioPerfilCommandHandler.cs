using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

public class EditarUsuarioPerfilCommandHandler : IRequestHandler<EditarUsuarioPerfilCommand,EditarUsuarioPerfilResponse>
{
    private readonly IGestionUsuarioPerfil _gestionUsuarioPerfil;

    public EditarUsuarioPerfilCommandHandler(IGestionUsuarioPerfil gestionUsuarioPerfil) => _gestionUsuarioPerfil = gestionUsuarioPerfil;
    

    public async Task<EditarUsuarioPerfilResponse> Handle(EditarUsuarioPerfilCommand request, CancellationToken cancellationToken)
    {
        EditarUsuarioPerfilResponse result = await _gestionUsuarioPerfil.EditarUsuarioPerfil(request!);

        return result;
    }
}
