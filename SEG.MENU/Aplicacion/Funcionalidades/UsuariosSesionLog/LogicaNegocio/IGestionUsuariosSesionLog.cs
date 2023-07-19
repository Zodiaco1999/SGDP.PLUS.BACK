using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

public interface IGestionUsuariosSesionLog
{
    Task<DataViewModel<ConsultarUsuariosSesionLogResponse>> ConsultarUsuariosSesionLog(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarUsuarioSesionLogPorIdResponse> ConsultarUsuarioSesionLogPorId(Guid logId);
    Task<CrearUsuarioSesionLogResponse> CrearUsuarioSesionLog(CrearUsuarioSesionLogCommand registroDto);
    Task<EditarUsuarioSesionLogResponse> EditarUsuarioSesionLog(EditarUsuarioSesionLogCommand registroDto);
}