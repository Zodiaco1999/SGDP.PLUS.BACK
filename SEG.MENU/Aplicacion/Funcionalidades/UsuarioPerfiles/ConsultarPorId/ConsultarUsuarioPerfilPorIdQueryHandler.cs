using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.ConsultarPorId;

public class ConsultarUsuarioPerfilPorIdQueryHandler : IRequestHandler<ConsultarUsuarioPerfilPorIdQuery, IEnumerable<ConsultarUsuarioPerfilPorIdResponse>>
{
    private readonly IGestionUsuarioPerfil _gestionUsuarioPerfil;

    public ConsultarUsuarioPerfilPorIdQueryHandler(IGestionUsuarioPerfil gestionUsuarioPerfil)
    {
        _gestionUsuarioPerfil = gestionUsuarioPerfil;
    }

    public async Task<IEnumerable<ConsultarUsuarioPerfilPorIdResponse>> Handle(ConsultarUsuarioPerfilPorIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _gestionUsuarioPerfil.ConsultarUsuarioPerfilPorId(request.usuarioId);

        return result;
    }
}
