using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

public record struct ConsultarUsuarioFotoPorIdQuery(string usuarioId) : IRequest<ConsultarUsuarioFotoPorIdResponse>;