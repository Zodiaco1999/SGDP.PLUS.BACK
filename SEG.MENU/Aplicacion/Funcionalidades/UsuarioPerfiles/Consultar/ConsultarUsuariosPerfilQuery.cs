using MediatR;
using SEG.Comun.General;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

public record struct ConsultarUsuariosPerfilQuery(string textoBusqueda, int pagina, int registrosPorPagina) : IRequest<DataViewModel<ConsultarUsuariosPerfilResponse>>;

