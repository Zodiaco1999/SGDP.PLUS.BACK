using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

public interface IGestionUsuariosSesion
{
    Task<DataViewModel<ConsultarUsuariosSesionResponse>> ConsultarUsuariosSesion(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarUsuarioSesionPorIdResponse> ConsultarUsuarioSesionPorId(string usuarioId);
    Task<CrearUsuarioSesionResponse> CrearUsuarioSesion(CrearUsuarioSesionCommand registroDto);
    Task<EditarUsuarioSesionResponse> EditarUsuarioSesion(EditarUsuarioSesionCommand registroDto);
}