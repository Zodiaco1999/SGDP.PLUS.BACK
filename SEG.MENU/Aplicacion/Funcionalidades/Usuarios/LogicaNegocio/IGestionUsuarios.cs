using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Lista;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

public interface IGestionUsuarios
{
    Task<DataViewModel<ConsultarUsuariosResponse>> ConsultarUsuarios(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarUsuarioPorIdResponse> ConsultarUsuarioPorId(string usuarioId);
    Task<CrearUsuarioResponse> CrearUsuario(CrearUsuarioCommand registroDto);
    Task<EditarUsuarioResponse> EditarUsuario(EditarUsuarioCommand registroDto);
    Task<ActivarInactivarUsuarioResponse> ActivarInactivarUsuario(string usuarioId);
    //Task<IEnumerable<ListaTipoDocumentoResponse>> ListaTipoDocumento();
}