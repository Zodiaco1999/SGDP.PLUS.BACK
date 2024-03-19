using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.BuscadorTercero;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaft;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaftTercero;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.LogicaNegocio;

public interface IGestionInformaApi
{
    Task<List<BuscadorTerceroResponse>> BuscadorTercero(BuscadorTerceroCommand command);
    Task<ObtenerInformeResponse> ObtenerInforme(ObtenerInformeCommand command);
    Task<ConsultaLaftResponse> ConsultaLaft(ConsultaLaftCommand command);
    Task<ConsultaLaftTerceroResponse> ConsultaLaftTercero(ConsultaLaftTerceroCommand command);
}