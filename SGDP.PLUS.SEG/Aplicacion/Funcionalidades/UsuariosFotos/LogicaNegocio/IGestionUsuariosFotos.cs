using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

public interface IGestionUsuariosFotos
{
    Task<DataViewModel<ConsultarUsuariosFotosResponse>> ConsultarUsuariosFotos(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarUsuarioFotoPorIdResponse> ConsultarUsuarioFotoPorId();
    Task<CrearUsuarioFotoResponse> CrearUsuarioFoto(CrearUsuarioFotoCommand registroDto);
    Task<EditarUsuarioFotoResponse> EditarUsuarioFoto(EditarUsuarioFotoCommand registroDto);
}

