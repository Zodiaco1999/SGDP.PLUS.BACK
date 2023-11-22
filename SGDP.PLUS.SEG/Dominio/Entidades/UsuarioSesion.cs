using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.SEG.Dominio.Entidades
{
    public class UsuarioSesion : CamposLog
    {
        public string UsuarioId { get; set; } = null!;

        public string SesionId { get; set; } = null!;

        public DateTime InicioSesion { get; set; }

        public string IpCliente { get; set; } = null!;

        public string TokenActualizacion { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;

        public virtual ICollection<UsuarioSesionLog> UsuarioSesionLogs { get; set; } = new List<UsuarioSesionLog>();
    }
}
