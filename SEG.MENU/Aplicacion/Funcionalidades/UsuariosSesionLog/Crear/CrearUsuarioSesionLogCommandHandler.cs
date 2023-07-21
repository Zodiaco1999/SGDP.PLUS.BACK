using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;

public class CrearUsuarioSesionLogCommandHandler : IRequestHandler<CrearUsuarioSesionLogCommand, CrearUsuarioSesionLogResponse>
{
    private readonly IGestionUsuariosSesionLog _gestionUsuariosSesionLog;
    public CrearUsuarioSesionLogCommandHandler(IGestionUsuariosSesionLog gestionUsuariosSesionLog) => _gestionUsuariosSesionLog = gestionUsuariosSesionLog;

    public async Task<CrearUsuarioSesionLogResponse> Handle(CrearUsuarioSesionLogCommand request, CancellationToken cancellationToken)
    {
        CrearUsuarioSesionLogResponse result = await _gestionUsuariosSesionLog.CrearUsuarioSesionLog(request);

        return result;
    }
}