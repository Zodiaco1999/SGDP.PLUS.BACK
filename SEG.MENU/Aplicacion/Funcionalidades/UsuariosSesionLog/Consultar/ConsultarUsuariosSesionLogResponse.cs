namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;

public record struct ConsultarUsuariosSesionLogResponse(
    Guid LogId,
    string UsuarioId,
    string SesionId,
    DateTime Fecha,
    string IpCliente,
    string DataSesion,
    string Accion,
    string? MsgValidacion);