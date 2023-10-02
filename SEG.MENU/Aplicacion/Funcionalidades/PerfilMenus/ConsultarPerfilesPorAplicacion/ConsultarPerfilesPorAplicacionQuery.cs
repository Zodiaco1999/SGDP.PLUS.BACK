using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPerfilesPorApp;
public record struct ConsultarPerfilesPorAplicacionQuery(Guid AplicacionId) : IRequest<IEnumerable<ConsultarPerfilesPorAplicacionResponse>>;