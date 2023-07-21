using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.SEG.Dominio.Entidades;

public class Modulo : CamposLog
{
    public Guid AplicacionId { get; set; }
    public Guid ModuloId { get; set; }
    public string NombreModulo { get; set; } = null!;
    public string DescModulo { get; set; } = null!;
    public string IconoPrefijo { get; set; } = null!;
    public string IconoNombre { get; set; } = null!;
    public int Orden { get; set; }
    public bool Activo { get; set; } = true;

    public virtual Aplication Apliation { get; set; } = null!;
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
