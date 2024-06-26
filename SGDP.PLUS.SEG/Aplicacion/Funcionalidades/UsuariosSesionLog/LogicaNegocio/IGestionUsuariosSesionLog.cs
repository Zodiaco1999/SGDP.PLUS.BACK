using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesionLog.LogicaNegocio;

public interface IGestionUsuariosSesionLog
{
    Task<DataViewModel<ConsultarUsuariosSesionLogResponse>> ConsultarUsuariosSesionLog(GetEntityQuery query);
    Task<ConsultarUsuarioSesionLogPorIdResponse> ConsultarUsuarioSesionLogPorId(Guid logId);
    Task<CrearUsuarioSesionLogResponse> CrearUsuarioSesionLog(CrearUsuarioSesionLogCommand registroDto);
    Task<EditarUsuarioSesionLogResponse> EditarUsuarioSesionLog(EditarUsuarioSesionLogCommand registroDto);
}