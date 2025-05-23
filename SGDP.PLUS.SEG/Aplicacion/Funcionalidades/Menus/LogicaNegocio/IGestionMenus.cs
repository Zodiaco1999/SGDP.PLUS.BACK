using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ActivarInactivar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarMenuUsuario;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarPorId;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

public interface IGestionMenus
{
    Task<DataViewModel<ConsultarMenusResponse>> ConsultarMenus(GetEntityQuery query, Guid aplicacionId, Guid? moduloId);
    Task<IEnumerable<ConsultarMenusPorParametrosResponse>> ConsultarMenusPorParametros(Guid aplicacionId, Guid? moduloId, string filtro);
    Task<ConsultarMenuPorIdResponse> ConsultarMenuPorId(Guid menuId);
    Task<IEnumerable<ConsultarMenuUsuarioResponse>> ConsultarMenuUsuario();
    Task<CrearMenuResponse> CrearMenu(CrearMenuCommand registroDto);
    Task<EditarMenuResponse> EditarMenu(EditarMenuCommand registroDto);
    Task<ActivarInactivarMenuResponse> ActivarInactivarMenu(Guid menuId);
}