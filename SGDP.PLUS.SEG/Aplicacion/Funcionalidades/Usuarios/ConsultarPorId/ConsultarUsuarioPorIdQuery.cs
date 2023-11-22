using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;

public record struct ConsultarUsuarioPorIdQuery(string usuarioId) : IRequest<ConsultarUsuarioPorIdResponse>;