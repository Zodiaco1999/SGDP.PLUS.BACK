using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

public class Admin
{
    [XmlElement("ADMINISTRADOR")]
    public List<AdministradorDto> Administradores { get; set; } = new List<AdministradorDto>();
}
