using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;

public record struct CrearUsuarioSesionLogCommand(
        Guid LogId,
        string UsuarioId,
        string SesionId,
        DateTime Fecha,
        string IpCliente,
        string DataSesion,
        string Accion,
        string? MsgValidacion) : IRequest<CrearUsuarioSesionLogResponse>;