using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme.DTO;

public class InformeAbreviado
{
    [XmlElement("INFORME_ABREVIADO_INTERNACIONAL")]
    public InformeAbreviadoInternacional InformeAbreviadoInternacional { get; set; } = new InformeAbreviadoInternacional();
}
