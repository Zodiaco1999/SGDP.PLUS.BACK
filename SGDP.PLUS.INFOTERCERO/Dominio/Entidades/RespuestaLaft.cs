using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

public class RespuestaLaft : Entity
{
    public Guid RespuestaLaftId { get; set; }

    public string NitTerceroAplica { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public string CodigoInforma { get; set; } = null!;

    public string IdentificacionConsultada { get; set; } = null!;

    public bool Alertado { get; set; }

    public string IdUsuarioSolicitud { get; set; } = null!;

    public string RespuestaJson { get; set; } = null!;

    public virtual ICollection<IlicitosRespuesta> IlicitosRespuesta { get; set; } = new List<IlicitosRespuesta>();

    public virtual InfoBasica InfoBasica { get; set; } = null!;
}
