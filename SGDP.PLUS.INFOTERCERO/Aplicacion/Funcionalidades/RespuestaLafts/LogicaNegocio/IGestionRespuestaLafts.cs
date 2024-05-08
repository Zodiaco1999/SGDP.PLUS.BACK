using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Consultar;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Crear;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Editar;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

public interface IGestionRespuestaLafts
{
    Task<DataViewModel<ConsultarRespuestaLaftsResponse>> ConsultarRespuestaLafts(string filtro, int pagina, int registrosPorPagina, string? ordenarPor = null, bool? direccionOrdenamientoAsc = null);
    Task<DataViewModel<ConsultarRespuestaLaftPorNitResponse>> ConsultarRespuestaLaftPorNit(GetEntityQuery query, string nit, bool actualiza);
    Task<CrearRespuestaLaftResponse> CrearRespuestaLaft(CrearRespuestaLaftCommand registroDto);
    Task<EditarRespuestaLaftResponse> EditarRespuestaLaft(EditarRespuestaLaftCommand registroDto);
    Task<IEnumerable<ConsultarDetalleLaftResponse>> ConsultarDetalleLaft(ConsultarDetalleLaftQuery query);
}