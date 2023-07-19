using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Crear;

public record struct CrearUsuarioSesionCommand(
        string UsuarioId,
        string SesionId,
        DateTime InicioSesion,
        string IpCliente,
        string TokenActualizacion) : IRequest<CrearUsuarioSesionResponse>;