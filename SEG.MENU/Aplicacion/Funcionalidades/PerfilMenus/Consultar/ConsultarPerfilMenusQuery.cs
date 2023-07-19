using MediatR;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Consultar;

public record struct ConsultarPerfilMenusQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarPerfilMenusResponse>>;
