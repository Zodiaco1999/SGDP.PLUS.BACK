using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;

public record struct ConsultarUsuarioPorIdQuery(string usuarioId) : IRequest<ConsultarUsuarioPorIdResponse>;