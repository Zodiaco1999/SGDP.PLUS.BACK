using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

public record struct ConsultarUsuarioFotoPorIdQuery(string usuarioId) : IRequest<ConsultarUsuarioFotoPorIdResponse>;