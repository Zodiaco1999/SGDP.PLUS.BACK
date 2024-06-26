using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;

public class ConsultarUsuariosSesionLogQueryHandler : IRequestHandler<ConsultarUsuariosSesionLogQuery, DataViewModel<ConsultarUsuariosSesionLogResponse>>
{
    private readonly IGestionUsuariosSesionLog _gestionUsuariosSesionLog;
    public ConsultarUsuariosSesionLogQueryHandler(IGestionUsuariosSesionLog gestionUsuariosSesionLog) => _gestionUsuariosSesionLog = gestionUsuariosSesionLog;

    public async Task<DataViewModel<ConsultarUsuariosSesionLogResponse>> Handle(ConsultarUsuariosSesionLogQuery request, CancellationToken cancellationToken)
        => await _gestionUsuariosSesionLog.ConsultarUsuariosSesionLog(request.Query);
}