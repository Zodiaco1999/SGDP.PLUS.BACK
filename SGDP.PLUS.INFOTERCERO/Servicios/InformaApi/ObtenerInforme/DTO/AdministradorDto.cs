using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme.DTO
{
    public class AdministradorDto
    {
        [XmlElement("CARGO")]
        public string Cargo { get; set; } = string.Empty;

        [XmlElement("CONSULTA_VINCULACIONES")]
        public string ConsultaVinculaciones { get; set; } = string.Empty;

        [XmlElement("CODIGO_CARGO")]
        public string CodigoCargo { get; set; } = string.Empty;

        [XmlElement("CONSULTAR_VINCULO")]
        public string ConsultarVinculo { get; set; } = string.Empty;

        [XmlElement("CEDULA")]
        public string Cedula { get; set; } = string.Empty;

        [XmlElement("FECHA_NOMBRAMIENTO")]
        public string FechaNombramiento { get; set; } = string.Empty;

        [XmlElement("CONSULTA_LAFT")]
        public string ConsultaLaft { get; set; } = string.Empty;

        [XmlElement("FECHA_CAMBIO_ADM")]
        public string FechaCambioAdm { get; set; } = string.Empty;

        [XmlElement("CONSULTAR_NO_DISPONIBLE")]
        public string ConsultarNoDisponible { get; set; } = string.Empty;

        [XmlElement("NOMBRE")]
        public string Nombre { get; set; } = string.Empty;
    }
}
