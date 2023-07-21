using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;

public record struct CrearUsuarioSesionLogCommand(
        Guid LogId,
        string UsuarioId,
        string SesionId,
        DateTime Fecha,
        string IpCliente,
        string DataSesion,
        string Accion,
        string? MsgValidacion) : IRequest<CrearUsuarioSesionLogResponse>;