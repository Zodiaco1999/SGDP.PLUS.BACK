using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades;

public class Menu : CamposLog
{
    public Guid AplicacionId { get; set; }
    public Guid ModuloId { get; set; }
    public Guid MenuId { get; set; }
    public string NombreMenu { get; set; } = null!;
    public string EtiquetaMenu { get; set; } = null!;
    public string DescMenu { get; set; } = null!;
    public string Url { get; set; } = null!;
    public short Orden { get; set; }
    public bool Consulta { get; set; }
    public bool Inserta { get; set; }
    public bool Actualiza { get; set; }
    public bool Elimina { get; set; }
    public bool Activa { get; set; }
    public bool Ejecuta { get; set; }
    public bool Activo { get; set; }
    public virtual Modulo Modulo { get; set; } = null!;
    public virtual ICollection<PerfilMenu> PerfilMenus { get; set; } = new List<PerfilMenu>();
}
