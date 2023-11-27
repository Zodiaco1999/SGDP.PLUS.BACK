using Newtonsoft.Json;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

public class ListaAdministradores
{
    [JsonProperty("ADMIN_CONSEJO")]
    public Admin AdminConsejo { get; set; } = new Admin();

    [JsonProperty("ADMIN_AUDITOR")]
    public Admin AdminAuditor { get; set; } = new Admin();

    [JsonProperty("ADMIN_FUNCION")]
    public Admin AdminFuncion { get; set; } = new Admin();

    [JsonProperty("ADMIN_FIRMA")]
    public Admin AdminFirma { get; set; } = new Admin();
}
