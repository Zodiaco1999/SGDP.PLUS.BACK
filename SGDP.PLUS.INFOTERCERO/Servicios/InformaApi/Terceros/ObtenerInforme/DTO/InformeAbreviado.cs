using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ObtenerInforme.DTO;

public class InformeAbreviado
{
    [XmlElement("INFORME_ABREVIADO_INTERNACIONAL")]
    public InformeAbreviadoInternacional InformeAbreviadoInternacional { get; set; } = new InformeAbreviadoInternacional();
}
