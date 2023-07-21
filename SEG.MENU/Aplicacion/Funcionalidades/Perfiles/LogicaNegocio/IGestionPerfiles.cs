using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

public interface IGestionPerfiles
{
    Task<DataViewModel<ConsultarPerfilesResponse>> ConsultarPerfiles(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarPerfilPorIdResponse> ConsultarPerfilPorId(Guid perfilId);
    Task<CrearPerfilResponse> CrearPerfil(CrearPerfilCommand registroDto);
    Task<EditarPerfilResponse> EditarPerfil(EditarPerfilCommand registroDto);
    Task<ActivarInactivarPerfilResponse> ActivarInactivarPerfil(Guid perfilId);
}