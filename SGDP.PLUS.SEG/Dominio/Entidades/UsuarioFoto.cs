using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.SEG.Dominio.Entidades
{
    public class UsuarioFoto : CamposLog
    {
        public string UsuarioId { get; set; } = null!;

        public string Foto { get; set; } = null!;

        public string Formato { get; set; } = null!;
   
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
