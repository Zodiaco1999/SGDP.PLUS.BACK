using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

public record struct ConsultarUsuariosFotoPorIdQuery(string usuarioId) : IRequest<ConsultarUsuariosFotoPorIdResponse>;