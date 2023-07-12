namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Crear;

public record struct CrearUsuarioSesionResponse(
        string UsuarioId,
        string SesionId,
        DateTime InicioSesion,
        string IpCliente,
        string TokenActualizacion);