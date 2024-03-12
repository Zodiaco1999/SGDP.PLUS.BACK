using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaft.DTO;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaft;

public class ConsultaLaftResponse
{
    public string IdentificacionConsultada { get; set; } = string.Empty;
    public ResumenRespuesta ResumenRespuesta { get; set; } = new();
    public List<ListaIlicitos> ListaIlicitos { get; set; } = new();
    public string RespuestaJson { get; set; } = string.Empty;
}