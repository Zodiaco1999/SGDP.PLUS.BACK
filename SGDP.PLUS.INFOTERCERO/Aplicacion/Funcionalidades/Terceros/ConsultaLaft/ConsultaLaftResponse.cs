using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft.DTO;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft;

public class ConsultaLaftResponse
{
    public ResumenRespuesta ResumenRespuesta { get; set; } = new();
    public List<ListaIlicitos> ListaIlicitos { get; set; } = new();
    public string RespuestaJson { get; set; } = string.Empty;
}