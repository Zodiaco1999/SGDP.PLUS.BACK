using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;

public record struct ConsultarAplicacionPorIdQuery(Guid AplicacionId): IRequest<ConsultarAplicacionPorIdResponse>;
