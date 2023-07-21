namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Editar;

public record struct EditarUsuarioSesionLogResponse(
        Guid LogId,
        string UsuarioId,
        string SesionId,
        DateTime Fecha,
        string IpCliente,
        string DataSesion,
        string Accion,
        string? MsgValidacion);