using MediatR;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;

public record struct ConsultarUsuariosFotosQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosFotosResponse>>;