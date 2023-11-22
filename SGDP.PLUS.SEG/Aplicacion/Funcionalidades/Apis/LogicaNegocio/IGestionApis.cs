using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Consultar;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Crear;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.LogicaNegocio;

public interface IGestionApis
{
    Task<IEnumerable<ConsultarApisResponse>> ConsultarApis(Guid aplicacionId);
    Task<CrearApiResponse> CrearApi(CrearApiCommand registroDto);
    Task EditarApi(EditarApiCommand registroDto);
    Task ActivarInactivarApi(Guid apiId);
}