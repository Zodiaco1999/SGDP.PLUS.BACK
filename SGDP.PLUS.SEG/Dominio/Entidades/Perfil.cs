using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.SEG.Dominio.Entidades;

public class Perfil : CamposLog
{
    public Guid PerfilId { get; set; } = Guid.NewGuid();
    public string NombrePerfil { get; set; } = string.Empty;
    public string DescPerfil { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;
    public virtual ICollection<PerfilMenu> PerfilMenus { get; set; } = new List<PerfilMenu>();
    public virtual ICollection<UsuarioPerfil> UsuarioPerfiles { get; set; } = new List<UsuarioPerfil>();
}
