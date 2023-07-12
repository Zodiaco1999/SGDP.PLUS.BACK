using MediatR;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;

public class ConsultarUsuariosSesionLogQueryHandler : IRequestHandler<ConsultarUsuariosSesionLogQuery, DataViewModel<ConsultarUsuariosSesionLogResponse>>
{
    private readonly IGestionUsuariosSesionLog _gestionUsuariosSesionLog;
    public ConsultarUsuariosSesionLogQueryHandler(IGestionUsuariosSesionLog gestionUsuariosSesionLog) => _gestionUsuariosSesionLog = gestionUsuariosSesionLog;

    public async Task<DataViewModel<ConsultarUsuariosSesionLogResponse>> Handle(ConsultarUsuariosSesionLogQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarUsuariosSesionLogResponse> result = await _gestionUsuariosSesionLog.ConsultarUsuariosSesionLog(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}