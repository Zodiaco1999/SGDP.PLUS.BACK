using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

public interface IGestionUsuarios
{
    Task<DataViewModel<ConsultarUsuariosResponse>> ConsultarUsuarios(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarUsuarioPorIdResponse> ConsultarUsuarioPorId(string usuarioId);
    Task<CrearUsuarioResponse> CrearUsuario(CrearUsuarioCommand registroDto);
    Task<EditarUsuarioResponse> EditarUsuario(EditarUsuarioCommand registroDto);
    Task<ActivarInactivarUsuarioResponse> ActivarInactivarUsuario(string usuarioId);
}