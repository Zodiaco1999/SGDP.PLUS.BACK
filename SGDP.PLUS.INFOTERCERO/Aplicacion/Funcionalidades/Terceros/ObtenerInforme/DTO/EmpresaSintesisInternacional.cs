using System.Xml.Serialization;
namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

public class EmpresaSintesisInternacional
{ 
    [XmlElement("ID_FISCAL")]
    public string IdFiscal { get; set; } = string.Empty;

    [XmlElement("FECHA_CONSTITUCION")]
    public string FechaConstitucion { get; set; } = string.Empty;

    [XmlElement("EMAIL")]
    public string Email { get; set; } = string.Empty;

    [XmlElement("LIT_ICI")]
    public string Ici { get; set; } = string.Empty;

    [XmlElement("FORMA_JURIDICA_COD")]
    public string FormaJuridicaCod { get; set; } = string.Empty;

    [XmlElement("ACTIVIDAD")]
    public string Actividad { get; set; } = string.Empty;

    [XmlElement("DENOMINACION")]
    public string Denominacion { get; set; } = string.Empty;

    [XmlElement("CIUDAD")]
    public string Ciudad { get; set; } = string.Empty;

    [XmlElement("DOMICILIO_SOCIAL")]
    public string DomicilioSocial { get; set; } = string.Empty;

    [XmlElement("TELEFONO")]
    public string Telefono { get; set; } = string.Empty;

    public string Resumen_Str { get; set; } = string.Empty;
}
