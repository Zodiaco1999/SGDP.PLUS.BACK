using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades
{
    public class UsuarioFoto : CamposLog
    {
        public string UsuarioId { get; set; } = null!;

        public string Foto { get; set; } = null!;

        public string Formato { get; set; } = null!;
   
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
