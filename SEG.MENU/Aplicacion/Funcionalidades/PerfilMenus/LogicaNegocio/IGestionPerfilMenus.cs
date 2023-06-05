using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio
{
    public interface IGestionPerfilMenus
    {
        Task<DataViewModel<ConsultarPerfilMenusResponse>> ConsultarPerfilMenus(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
        Task<ConsultarPerfilMenuPorIdResponse> ConsultarPerfilMenu(Guid perfilId);
        Task<CrearPerfilMenusResponse> CrearPerfilMenu(CrearPerfilMenusCommand registroDto);
        Task<EditarPerfilMenusResponse> ActualizarPerfilMenu(EditarPerfilMenusCommand registroDto);
    }
}