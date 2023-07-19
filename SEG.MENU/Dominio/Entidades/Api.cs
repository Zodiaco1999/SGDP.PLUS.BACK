using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades;

public class Api : CamposLog
{
    public Guid AplicacionId { get; set; }
    public Guid ApiId { get; set; }
    public string NombreApi { get; set; } = null!;
    public string DescripcionApi { get; set; } = string.Empty;
    public string UrlPrueba { get; set; } = string.Empty;
    public string UrlProduccion { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;

    public virtual Aplication Aplication { get; set; } = null!;
}
