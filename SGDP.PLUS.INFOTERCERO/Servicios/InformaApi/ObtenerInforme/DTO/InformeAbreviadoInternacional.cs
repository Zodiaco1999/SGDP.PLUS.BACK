using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme.DTO
{
    [Serializable]
    [XmlRoot("INFORME_ABREVIADO_INTERNACIONAL")]
    public class InformeAbreviadoInternacional
    {
        [XmlElement("ETIQUETA_EMPRESA_SINTESIS_INTERNACIONAL")]
        public EmpresaSintesisInternacional EmpresaSintesisInternacional { get; set; } = new();

        [XmlElement("ADMINISTRADORES_PRINCIPALES_INTERNACIONAL")]
        public AdministradoresPrincipalesInternacional AdministradoresPrincipalesInternacional { get; set; } = new();
    }
}
