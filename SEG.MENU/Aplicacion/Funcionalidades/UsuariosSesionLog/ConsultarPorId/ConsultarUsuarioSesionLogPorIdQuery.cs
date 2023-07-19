using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.ConsultarPorId;

public record struct ConsultarUsuarioSesionLogPorIdQuery(Guid logId) : IRequest<ConsultarUsuarioSesionLogPorIdResponse>;