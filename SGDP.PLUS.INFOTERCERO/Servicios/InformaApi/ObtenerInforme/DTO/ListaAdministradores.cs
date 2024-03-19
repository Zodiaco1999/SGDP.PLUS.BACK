using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme.DTO;

public class ListaAdministradores
{
    [XmlElement("ADMIN_CONSEJO")]
    public Admin AdminConsejo { get; set; } = new Admin();

    [XmlElement("ADMIN_AUDITOR")]
    public Admin AdminAuditor { get; set; } = new Admin();

    [XmlElement("ADMIN_FUNCION")]
    public Admin AdminFuncion { get; set; } = new Admin();

    [XmlElement("ADMIN_FIRMA")]
    public Admin AdminFirma { get; set; } = new Admin();
}
