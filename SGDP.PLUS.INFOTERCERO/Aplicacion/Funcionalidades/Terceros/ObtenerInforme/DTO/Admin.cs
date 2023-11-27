using Newtonsoft.Json;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

public class Admin
{
    [JsonProperty("ADMINISTRADOR")]
    public List<Administrador> Administradores { get; set; } = new List<Administrador>();
}
