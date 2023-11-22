using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ActivarInactivar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Consultar;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ConsultarPorId;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Crear;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Editar;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;

public interface IGestionTipoPersonas
{
    Task<DataViewModel<ConsultarTipoPersonasResponse>> ConsultarTipoPersonas(string filtro, int pagina, int registrosPorPagina,string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<ConsultarTipoPersonaPorIdResponse> ConsultarTipoPersonaPorId(Guid tipopersonaId);
    Task<CrearTipoPersonaResponse> CrearTipoPersona(CrearTipoPersonaCommand registroDto);
    Task<EditarTipoPersonaResponse> EditarTipoPersona(EditarTipoPersonaCommand registroDto);
    Task<ActivarInactivarTipoPersonaResponse> ActivarInactivarTipoPersona(Guid tipopersonaId);
}