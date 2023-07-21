using MediatR;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;

public record struct ConsultarUsuariosSesionLogQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosSesionLogResponse>>;