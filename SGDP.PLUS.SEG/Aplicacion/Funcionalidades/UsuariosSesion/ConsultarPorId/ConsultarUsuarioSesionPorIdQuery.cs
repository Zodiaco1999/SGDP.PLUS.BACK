using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;

public record struct ConsultarUsuarioSesionPorIdQuery(string usuarioId) : IRequest<ConsultarUsuarioSesionPorIdResponse>;