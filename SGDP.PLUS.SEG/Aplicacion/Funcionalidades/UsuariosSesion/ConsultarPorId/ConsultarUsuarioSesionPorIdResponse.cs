namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;

public record struct ConsultarUsuarioSesionPorIdResponse(
        string UsuarioId,
        string SesionId,
        DateTime InicioSesion,
        string IpCliente,
        string TokenActualizacion,
        string CreaUsuario,
        DateTime CreaFecha,
        string ModificaUsuario,
        DateTime ModificaFecha);