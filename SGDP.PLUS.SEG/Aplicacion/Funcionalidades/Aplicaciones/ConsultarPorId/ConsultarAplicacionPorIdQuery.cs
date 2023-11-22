using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;

public record struct ConsultarAplicacionPorIdQuery(Guid AplicacionId): IRequest<ConsultarAplicacionPorIdResponse>;
