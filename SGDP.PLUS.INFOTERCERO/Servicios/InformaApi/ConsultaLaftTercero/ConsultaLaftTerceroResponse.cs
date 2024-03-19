using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaft.DTO;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaftTercero;

public class ConsultaLaftTerceroResponse
{
    public ResumenRespuesta ResumenRespuesta { get; set; } = new();
    public List<ListaIlicitos> ListaIlicitos { get; set; } = new();
}