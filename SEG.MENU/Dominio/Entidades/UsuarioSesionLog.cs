using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades
{
    public class UsuarioSesionLog : CamposLog
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
