using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;

public class CrearUsuarioPerfilCommandHandler : IRequestHandler<CrearUsuarioPerfilCommand, CrearUsuarioPerfilResponse>
{
    private readonly IGestionUsuarioPerfil _gestionUsuarioPerfil;

    public CrearUsuarioPerfilCommandHandler(IGestionUsuarioPerfil gestionUsuarioPerfil) => _gestionUsuarioPerfil = gestionUsuarioPerfil;

    public async Task<CrearUsuarioPerfilResponse> Handle(CrearUsuarioPerfilCommand request, CancellationToken cancellationToken)
    {
        return await _gestionUsuarioPerfil.CrearUsuarioPerfil(request);
    }
}
