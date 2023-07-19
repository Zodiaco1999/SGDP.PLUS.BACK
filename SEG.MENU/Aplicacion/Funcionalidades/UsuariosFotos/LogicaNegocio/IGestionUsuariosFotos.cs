using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

public interface IGestionUsuariosFotos
{
    Task<DataViewModel<ConsultarUsuariosFotosResponse>> ConsultarUsuariosFotos(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarUsuarioFotoPorIdResponse> ConsultarUsuarioFotoPorId(string usuarioId);
    Task<CrearUsuarioFotoResponse> CrearUsuarioFoto(CrearUsuarioFotoCommand registroDto);
    Task<EditarUsuarioFotoResponse> EditarUsuarioFoto(EditarUsuarioFotoCommand registroDto);
}

