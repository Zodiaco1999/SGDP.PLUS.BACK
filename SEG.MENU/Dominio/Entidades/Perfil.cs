using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades;

public class Perfil : CamposLog
{
    public Guid PerfilId { get; set; } = Guid.NewGuid();
    public string NombrePerfil { get; set; } = string.Empty;
    public string DescPerfil { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;
    public virtual PerfilMenu? PerfilMenu { get; set; }
    public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; } = new List<UsuarioPerfil>();
}
