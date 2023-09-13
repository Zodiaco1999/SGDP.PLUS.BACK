using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPerfilesPorApp;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Editar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Especificacion;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio
{
    public interface IGestionPerfilMenus
    {
        Task<DataViewModel<ConsultarPerfilMenusResponse>> ConsultarPerfilMenus(Guid perfilId, Guid? aplicaionId, Guid? moduloId, string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);

        Task<IEnumerable<ConsultarPerfilesPorAplicacionResponse>> ConsultarPerfilesPorAplicacion(Guid aplicacionId);
        Task<IEnumerable<ConsultarPerfilMenusPorIdResponse>> ConsultarPerfilMenuPorId(Guid perfilId);
        Task<CrearPerfilMenuResponse> CrearPerfilMenu(CrearPerfilMenuCommand registroDto);
        Task EditarPerfilMenu(List<EditarPerfilMenuCommand> perfilMenusDto, Guid perfilId);
    }
}