namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;

public record struct CrearUsuarioSesionLogResponse(
        Guid LogId,
        string UsuarioId,
        string SesionId,
        DateTime Fecha,
        string IpCliente,
        string DataSesion,
        string Accion,
        string? MsgValidacion);