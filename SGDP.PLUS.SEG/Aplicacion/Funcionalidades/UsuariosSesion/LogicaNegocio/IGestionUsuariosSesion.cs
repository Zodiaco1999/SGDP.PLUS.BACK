using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

public interface IGestionUsuariosSesion
{
    Task<DataViewModel<ConsultarUsuariosSesionResponse>> ConsultarUsuariosSesion(GetEntityQuery query);
    Task<ConsultarUsuarioSesionPorIdResponse> ConsultarUsuarioSesionPorId(string usuarioId);
    Task<CrearUsuarioSesionResponse> CrearUsuarioSesion(CrearUsuarioSesionCommand registroDto);
    Task<EditarUsuarioSesionResponse> EditarUsuarioSesion(EditarUsuarioSesionCommand registroDto);
}