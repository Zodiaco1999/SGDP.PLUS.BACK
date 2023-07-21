using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.ConsultarPorId;

public class ConsultarUsuarioSesionLogPorIdQueryHandler : IRequestHandler<ConsultarUsuarioSesionLogPorIdQuery, ConsultarUsuarioSesionLogPorIdResponse>
{
    private readonly IGestionUsuariosSesionLog _gestionUsuariosSesionLog;
    public ConsultarUsuarioSesionLogPorIdQueryHandler(IGestionUsuariosSesionLog gestionUsuariosSesionLog) => _gestionUsuariosSesionLog = gestionUsuariosSesionLog;

    public async Task<ConsultarUsuarioSesionLogPorIdResponse> Handle(ConsultarUsuarioSesionLogPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarUsuarioSesionLogPorIdResponse result = await _gestionUsuariosSesionLog.ConsultarUsuarioSesionLogPorId(request.logId);

        return result;
    }
}