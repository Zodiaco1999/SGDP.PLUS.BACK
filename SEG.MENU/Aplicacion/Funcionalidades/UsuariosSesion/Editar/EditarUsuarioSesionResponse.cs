namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Editar;

public record struct EditarUsuarioSesionResponse(
        string UsuarioId,
        string SesionId,
        DateTime InicioSesion,
        string IpCliente,
        string TokenActualizacion,
        string CreaUsuario,
        DateTime CreaFecha,
        string ModificaUsuario,
        DateTime ModificaFecha);