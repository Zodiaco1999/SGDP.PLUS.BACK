using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Editar;

public class EditarUsuarioSesionLogCommandHandler : IRequestHandler<EditarUsuarioSesionLogCommand, EditarUsuarioSesionLogResponse>
{
    private readonly IGestionUsuariosSesionLog _gestionUsuariosSesionLog;
    public EditarUsuarioSesionLogCommandHandler(IGestionUsuariosSesionLog gestionUsuariosSesionLog) => _gestionUsuariosSesionLog = gestionUsuariosSesionLog;

    public async Task<EditarUsuarioSesionLogResponse> Handle(EditarUsuarioSesionLogCommand request, CancellationToken cancellationToken)
    {
        EditarUsuarioSesionLogResponse result = await _gestionUsuariosSesionLog.EditarUsuarioSesionLog(request);

        return result;
    }
}