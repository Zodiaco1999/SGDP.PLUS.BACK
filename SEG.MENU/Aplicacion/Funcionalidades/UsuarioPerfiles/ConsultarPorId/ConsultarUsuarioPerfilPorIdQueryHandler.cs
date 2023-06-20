using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public class ConsultarUsuarioPerfilPorIdQueryHandler : IRequestHandler<ConsultarUsuarioPerfilPorIdQuery, ConsultarUsuarioPerfilPorIdResponse>
{
    private readonly IGestionUsuarioPerfil _gestionUsuarioPerfil;

    public ConsultarUsuarioPerfilPorIdQueryHandler(IGestionUsuarioPerfil gestionUsuarioPerfil)
    {
        _gestionUsuarioPerfil = gestionUsuarioPerfil;
    }

    public async Task<ConsultarUsuarioPerfilPorIdResponse> Handle(ConsultarUsuarioPerfilPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarUsuarioPerfilPorIdResponse res = await _gestionUsuarioPerfil.ConsultarUsuarioPerfil(request.perfilId, request.usuarioId);

        return res;
    }
}
