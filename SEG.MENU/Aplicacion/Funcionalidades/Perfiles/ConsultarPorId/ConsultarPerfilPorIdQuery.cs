using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;

public record struct ConsultarPerfilPorIdQuery(Guid PerfilId) : IRequest<ConsultarPerfilPorIdResponse>;
