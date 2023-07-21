using SEG.Comun.Entidades;
using SEG.Comun.General;

namespace SGDP.PLUS.SEG.Dominio.Entidades
{
    public class UsuarioSesionLog : Entity
    {
        public Guid LogId { get; set; }
        public string UsuarioId { get; set; } = null!;

        public string SesionId { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string IpCliente { get; set; } = null!;

        public string DataSesion { get; set; } = null!;

        public string Accion { get; set; } = null!;

        public string? MsgValidacion { get; set; }

        public virtual UsuarioSesion UsuarioSesion { get; set; } = null!;
    }
}
