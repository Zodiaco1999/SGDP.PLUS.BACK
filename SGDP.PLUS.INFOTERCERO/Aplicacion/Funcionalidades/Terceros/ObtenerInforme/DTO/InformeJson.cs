using Newtonsoft.Json;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO
{
    public class InformeJson
    {
        [JsonProperty("ETIQUETA_EMPRESA_SINTESIS_INTERNACIONAL")]
        public EmpresaSintesisInternacional EmpresaSintesisInternacional { get; set; } = new();

        [JsonProperty("ADMINISTRADORES_PRINCIPALES_INTERNACIONAL")]
        public AdministradoresPrincipalesInternacional AdministradoresPrincipalesInternacional { get; set; } = new();
    }
}
