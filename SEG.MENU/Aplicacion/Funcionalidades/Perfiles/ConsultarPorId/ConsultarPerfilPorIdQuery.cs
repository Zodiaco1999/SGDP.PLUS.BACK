using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;

public record struct ConsultarPerfilPorIdQuery(Guid PerfilId) : IRequest<ConsultarPerfilPorIdResponse>;
