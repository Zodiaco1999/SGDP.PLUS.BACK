using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Consultar;

public record struct ConsultarApisQuery(Guid AplicacionId) : IRequest<IEnumerable<ConsultarApisResponse>>;
