using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades;

public class PerfilMenu : CamposLog
{
    public Guid PerfilId { get; set; }
    public Guid AplicacionId { get; set; }
    public Guid ModuloId { get; set; }
    public Guid MenuId { get; set; }
    public bool Consulta { get; set; }
    public bool Inserta { get; set; }
    public bool Actualiza { get; set; }
    public bool Elimina { get; set; }
    public bool Activa { get; set; }
    public bool Ejecuta { get; set; }
    public virtual Menu Menu { get; set; } = null!;
    public virtual Perfil Perfil { get; set; } = null!;
}
