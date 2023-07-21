using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.ConsultarPorId;

public record struct ConsultarUsuarioSesionLogPorIdQuery(Guid logId) : IRequest<ConsultarUsuarioSesionLogPorIdResponse>;