using System.Xml.Serialization;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme.DTO;

public class AdministradoresPrincipalesInternacional
{
    [XmlElement("LINK_LISTA_COMPLETA")]
    public string LinkListaCompleta { get; set; } = string.Empty;

    [XmlElement("NUM_ADMINISTRADORES")]
    public int NumAdministradores { get; set; }

    [XmlElement("LISTA_ADMINISTRADORES")]
    public ListaAdministradores ListaAdministradores { get; set; } = new();
}