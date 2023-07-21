using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades
{
    public class TipoDocumento : CamposLog
    {
        public int TipoDocumentoId { get; set; }

        public string? Nombre { get; set; }

        public string? Abreviatura { get; set; }

        public bool? Activo { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
