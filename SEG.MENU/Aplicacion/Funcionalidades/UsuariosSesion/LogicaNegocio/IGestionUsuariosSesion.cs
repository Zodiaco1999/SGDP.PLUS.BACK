using SEG.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosSesion.LogicaNegocio;

public interface IGestionUsuariosSesion
{
    Task<DataViewModel<ConsultarUsuariosSesionResponse>> ConsultarUsuariosSesion(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarUsuarioSesionPorIdResponse> ConsultarUsuarioSesionPorId(string usuarioId);
    Task<CrearUsuarioSesionResponse> CrearUsuarioSesion(CrearUsuarioSesionCommand registroDto);
    Task<EditarUsuarioSesionResponse> EditarUsuarioSesion(EditarUsuarioSesionCommand registroDto);
}