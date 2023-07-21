using MediatR;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Consultar;

public record struct ConsultarUsuariosQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosResponse>>;