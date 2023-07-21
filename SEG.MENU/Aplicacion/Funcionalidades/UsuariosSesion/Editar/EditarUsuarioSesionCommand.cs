using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Editar;

public record struct EditarUsuarioSesionCommand(
        string UsuarioId,
        string SesionId,
        DateTime InicioSesion,
        string IpCliente,
        string TokenActualizacion) : IRequest<EditarUsuarioSesionResponse>;