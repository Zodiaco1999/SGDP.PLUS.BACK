using MediatR;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

public record struct ConsultarAplicacionesQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarAplicacionesResponse>>;
