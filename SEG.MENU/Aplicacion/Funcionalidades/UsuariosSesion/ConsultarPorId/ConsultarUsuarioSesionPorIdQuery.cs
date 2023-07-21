using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;

public record struct ConsultarUsuarioSesionPorIdQuery(string usuarioId) : IRequest<ConsultarUsuarioSesionPorIdResponse>;