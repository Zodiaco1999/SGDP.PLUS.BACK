using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.BuscadorTercero;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaft;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaftTercero;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ObtenerInforme;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.LogicaNegocio;

public interface IGestionTerceros
{
    Task<List<BuscadorTerceroResponse>> BuscadorTercero(BuscadorTerceroCommand command);
    Task<ObtenerInformeResponse> ObtenerInforme(ObtenerInformeCommand command);
    Task<ConsultaLaftResponse> ConsultaLaft(ConsultaLaftCommand command);
    Task<ConsultaLaftTerceroResponse> ConsultaLaftTercero(ConsultaLaftTerceroCommand command);
}