using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaft.DTO;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaftTercero;

public class ConsultaLaftTerceroResponse
{
    public ResumenRespuesta ResumenRespuesta { get; set; } = new();
    public List<ListaIlicitos> ListaIlicitos { get; set; } = new();
}