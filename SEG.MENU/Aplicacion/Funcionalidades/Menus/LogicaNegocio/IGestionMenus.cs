using Microsoft.AspNetCore.Mvc;
using SEG.Comun.General;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.ActivarInactivar;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.Consultar;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.ConsultarPorId;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Menus.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

public interface IGestionMenus
{
    Task<DataViewModel<ConsultarMenusResponse>> ConsultarMenus(Guid aplicacionId, Guid moduloId, string filtro, int pagina, 
        int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarMenuPorIdResponse> ConsultarMenuPorId(Guid menuId);
    Task<CrearMenuResponse> CrearMenu(CrearMenuCommand registroDto);
    Task<EditarMenuResponse> EditarMenu(EditarMenuCommand registroDto);
    Task<ActivarInactivarMenuResponse> ActivarInactivarMenu(Guid menuId);
}