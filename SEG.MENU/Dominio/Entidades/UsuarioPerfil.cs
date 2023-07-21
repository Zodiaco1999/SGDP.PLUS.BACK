using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.SEG.Dominio.Entidades
{
    public class UsuarioPerfil : CamposLog
    {
        public string UsuarioId { get; set; } = null!;

        public Guid PerfilId { get; set; }

        public DateTime FechaInicia { get; set; }

        public DateTime FechaTermina { get; set; }

        public virtual Perfil Perfil { get; set; } = null!;

        public virtual Usuario Usuario { get; set; } = null!;
    }
}
