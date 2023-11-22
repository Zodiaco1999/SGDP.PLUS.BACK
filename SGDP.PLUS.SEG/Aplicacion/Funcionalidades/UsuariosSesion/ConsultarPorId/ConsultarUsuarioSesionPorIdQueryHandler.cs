using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;

public class ConsultarUsuarioSesionPorIdQueryHandler : IRequestHandler<ConsultarUsuarioSesionPorIdQuery, ConsultarUsuarioSesionPorIdResponse>
{
    private readonly IGestionUsuariosSesion _gestionUsuariosSesion;
    public ConsultarUsuarioSesionPorIdQueryHandler(IGestionUsuariosSesion gestionUsuariosSesion) => _gestionUsuariosSesion = gestionUsuariosSesion;

    public async Task<ConsultarUsuarioSesionPorIdResponse> Handle(ConsultarUsuarioSesionPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarUsuarioSesionPorIdResponse result = await _gestionUsuariosSesion.ConsultarUsuarioSesionPorId(request.usuarioId);

        return result;
    }
}