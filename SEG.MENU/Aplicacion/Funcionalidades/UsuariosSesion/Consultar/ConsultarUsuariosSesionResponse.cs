namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;

public record struct ConsultarUsuariosSesionResponse(
        string UsuarioId,
        string SesionId,
        DateTime InicioSesion,
        string IpCliente,
        string TokenActualizacion,
        string CreaUsuario,
        DateTime CreaFecha,
        string ModificaUsuario,
        DateTime ModificaFecha);