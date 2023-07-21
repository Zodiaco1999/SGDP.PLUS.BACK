using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio
{
    public interface IGestionPerfilMenus
    {
        Task<DataViewModel<ConsultarPerfilMenusResponse>> ConsultarPerfilMenus(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
        Task<ConsultarPerfilMenuPorIdResponse> ConsultarPerfilMenuPorId(Guid perfilId);
        Task<CrearPerfilMenuResponse> CrearPerfilMenu(CrearPerfilMenuCommand registroDto);
        Task<EditarPerfilMenuResponse> EditarPerfilMenu(EditarPerfilMenuCommand registroDto);
    }
}