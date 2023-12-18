using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.BuscadorTercero;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaftTercero;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

public interface IGestionTerceros
{
    Task<List<BuscadorTerceroResponse>> BuscadorTercero(BuscadorTerceroCommand command);
    Task<ObtenerInformeResponse> ObtenerInforme(ObtenerInformeCommand command);
    Task<ConsultaLaftResponse> ConsultaLaft(ConsultaLaftCommand command);
    Task<ConsultaLaftTerceroResponse> ConsultaLaftTercero(ConsultaLaftTerceroCommand command);
}