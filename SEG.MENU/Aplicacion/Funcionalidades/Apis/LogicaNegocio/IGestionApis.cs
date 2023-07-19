using SEG.MENU.Aplicacion.Funcionalidades.Apis.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Apis.Editar;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.LogicaNegocio;

public interface IGestionApis
{
    Task<CrearApiResponse> CrearApi(CrearApiCommand registroDto);
    Task EditarApi(EditarApiCommand registroDto);
    Task ActivarInactivarApi(Guid apiId);
}