using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Consultar;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.ConsultarPorId;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.LogicaNegocio;

public interface IGestionIlicitosRespuestas
{
    Task<DataViewModel<ConsultarIlicitosRespuestasResponse>> ConsultarIlicitosRespuestas(ConsultarIlicitosRespuestasQuery query);
    Task<DataViewModel<ConsultarIlicitosRespuestaPorIdResponse>> ConsultarIlicitosRespuestaPorId(ConsultarIlicitosRespuestaPorIdQuery query);
}