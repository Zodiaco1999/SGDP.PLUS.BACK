using Newtonsoft.Json;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

public class EmpresaSintesisInternacional
{ 
    [JsonProperty("ID_FISCAL")]
    public string IdFiscal { get; set; } = string.Empty;

    [JsonProperty("FECHA_CONSTITUCION")]
    public string FechaConstitucion { get; set; } = string.Empty;

    [JsonProperty("EMAIL")]
    public string Email { get; set; } = string.Empty;

    [JsonProperty("LIT_ICI")]
    public string Ici { get; set; } = string.Empty;

    [JsonProperty("FORM_JURIDICA_COD")]
    public string FormaJuridicaCod { get; set; } = string.Empty;

    [JsonProperty("ACTIVIDAD")]
    public string Actividad { get; set; } = string.Empty;

    [JsonProperty("DENOMINACION")]
    public string Denominacion { get; set; } = string.Empty;

    [JsonProperty("CIUDAD")]
    public string Ciudad { get; set; } = string.Empty;

    [JsonProperty("DOMICILIO_SOCIAL")]
    public string DomicilioSocial { get; set; } = string.Empty;

    [JsonProperty("TELEFONO")]
    public string Telefono { get; set; } = string.Empty;
}
