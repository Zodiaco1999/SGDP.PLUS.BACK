using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Editar;

public record struct EditarUsuarioSesionLogCommand(
        Guid LogId,
        string UsuarioId,
        string SesionId,
        DateTime Fecha,
        string IpCliente,
        string DataSesion,
        string Accion,
        string? MsgValidacion) : IRequest<EditarUsuarioSesionLogResponse>;