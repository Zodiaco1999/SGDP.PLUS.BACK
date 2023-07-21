using MediatR;
using SEG.Comun.General;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Consultar;

public record struct ConsultarUsuariosQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosResponse>>;