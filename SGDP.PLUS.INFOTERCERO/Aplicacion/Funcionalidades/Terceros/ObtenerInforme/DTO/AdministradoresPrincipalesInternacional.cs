using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

public class AdministradoresPrincipalesInternacional
{
    [JsonProperty("LINK_LISTA_COMPLETA")]
    public string LinkListaCompleta { get; set; } = string.Empty;

    [JsonProperty("NUM_ADMINISTRADORES")]
    public int NumAdministradores { get; set; }

    [JsonProperty("LISTA_ADMINISTRADORES")]
    public ListaAdministradores ListaAdministradores { get; set; } = new();
}