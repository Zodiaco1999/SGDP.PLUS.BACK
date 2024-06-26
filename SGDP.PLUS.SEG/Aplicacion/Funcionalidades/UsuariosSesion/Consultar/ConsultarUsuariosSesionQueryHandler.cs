using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;

public class ConsultarUsuariosSesionQueryHandler : IRequestHandler<ConsultarUsuariosSesionQuery, DataViewModel<ConsultarUsuariosSesionResponse>>
{
    private readonly IGestionUsuariosSesion _gestionUsuariosSesion;
    public ConsultarUsuariosSesionQueryHandler(IGestionUsuariosSesion gestionUsuariosSesion) => _gestionUsuariosSesion = gestionUsuariosSesion;

    public async Task<DataViewModel<ConsultarUsuariosSesionResponse>> Handle(ConsultarUsuariosSesionQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarUsuariosSesionResponse> result = await _gestionUsuariosSesion.ConsultarUsuariosSesion(request.Query);

        return result;
    }
}