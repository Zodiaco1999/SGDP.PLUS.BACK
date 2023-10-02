using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Consultar;

public record struct ConsultarModulosQuery(Guid AplicacionId) : IRequest<IEnumerable<ConsultarModulosResponse>>;