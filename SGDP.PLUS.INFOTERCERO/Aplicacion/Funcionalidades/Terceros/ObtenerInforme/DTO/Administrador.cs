using Newtonsoft.Json;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO
{
    public class Administrador
    {
        [JsonProperty("CARGO")]
        public string Cargo { get; set; } = string.Empty;

        [JsonProperty("CONSULTA_VINCULACIONES")]
        public string ConsultaVinculaciones { get; set; } = string.Empty;

        [JsonProperty("CODIGO_CARGO")]
        public string CodigoCargo { get; set; } = string.Empty;

        [JsonProperty("CONSULTAR_VINCULO")]
        public string ConsultarVinculo { get; set; } = string.Empty;

        [JsonProperty("CEDULA")]
        public string Cedula { get; set; } = string.Empty;

        [JsonProperty("FECHA_NOMBRAMIENTO")]
        public string FechaNombramiento { get; set; } = string.Empty;

        [JsonProperty("CONSULTA_LAFT")]
        public string ConsultaLaft { get; set; } = string.Empty;

        [JsonProperty("FECHA_CAMBIO_ADM")]
        public string FechaCambioAdm { get; set; } = string.Empty;

        [JsonProperty("CONSULTAR_NO_DISPONIBLE")]
        public string ConsultarNoDisponible { get; set; } = string.Empty;

        [JsonProperty("NOMBRE")]
        public string Nombre { get; set; } = string.Empty;
    }
}
