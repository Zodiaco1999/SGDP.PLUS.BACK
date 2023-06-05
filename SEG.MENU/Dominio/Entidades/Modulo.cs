using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades;

public class Modulo : CamposLog
{
    public Guid AplicacionId { get; set; } = Guid.NewGuid();
    public Guid ModuloId { get; set; } = Guid.NewGuid();
    public string NombreModulo { get; set; } = string.Empty;
    public string DescModulo { get; set; } = string.Empty;
    public string IconoPrefijo { get; set; } = string.Empty;
    public string IconoNombre { get; set; } = string.Empty;
    public int Orden { get; set; }
    public bool Activo { get; set; } = true;
    public virtual Aplication Apliation { get; set; } = null!;
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
