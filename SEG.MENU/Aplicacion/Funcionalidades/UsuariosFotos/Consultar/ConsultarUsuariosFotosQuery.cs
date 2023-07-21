using MediatR;
using SEG.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;

public record struct ConsultarUsuariosFotosQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosFotosResponse>>;