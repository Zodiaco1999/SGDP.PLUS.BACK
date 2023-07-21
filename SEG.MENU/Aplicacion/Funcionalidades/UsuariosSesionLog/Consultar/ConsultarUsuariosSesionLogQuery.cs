using MediatR;
using SEG.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;

public record struct ConsultarUsuariosSesionLogQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosSesionLogResponse>>;