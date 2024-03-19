using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme.DTO;

public class Admin
{
    [XmlElement("ADMINISTRADOR")]
    public List<AdministradorDto> Administradores { get; set; } = new List<AdministradorDto>();
}
