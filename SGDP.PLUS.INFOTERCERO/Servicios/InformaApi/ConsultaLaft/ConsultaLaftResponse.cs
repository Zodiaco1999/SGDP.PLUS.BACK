using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaft.DTO;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaft;

public class ConsultaLaftResponse
{
    public string IdentificacionConsultada { get; set; } = string.Empty;
    public ResumenRespuesta ResumenRespuesta { get; set; } = new();
    public List<ListaIlicitos> ListaIlicitos { get; set; } = new();
    public string RespuestaJson { get; set; } = string.Empty;
}