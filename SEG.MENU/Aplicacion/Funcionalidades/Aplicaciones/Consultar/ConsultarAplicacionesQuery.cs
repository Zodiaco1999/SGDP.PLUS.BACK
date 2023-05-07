using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

public record struct ConsultarAplicacionesQuery() : IRequest<IReadOnlyList<ConsultarAplicacionesResponse>>;
