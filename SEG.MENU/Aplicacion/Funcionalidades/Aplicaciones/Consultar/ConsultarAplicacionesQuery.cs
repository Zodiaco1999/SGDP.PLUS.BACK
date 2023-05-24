using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

public record struct ConsultarAplicacionesQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<IReadOnlyList<ConsultarAplicacionesResponse>>;
