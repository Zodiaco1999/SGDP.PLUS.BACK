using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

public interface IGestionPerfiles
{
    Task<DataViewModel<ConsultarPerfilesResponse>> ConsultarPerfiles(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarPerfilPorIdResponse> ConsultarPerfilPorId(Guid perfilId);
    Task<CrearPerfilResponse> CrearPerfil(CrearPerfilCommand registroDto);
    Task<EditarPerfilResponse> EditarPerfil(EditarPerfilCommand registroDto);
    Task<ActivarInactivarPerfilResponse> ActivarInactivarPerfil(Guid perfilId);
}