using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

public class IlicitosRespuesta : Entity
{
    public Guid RespuestaLaftId { get; set; }

    public string NumReg { get; set; } = null!;

    public string PorcentajeCoincidencia { get; set; } = null!;

    public string Coincidencia { get; set; } = null!;

    public string ConsultaRealizada { get; set; } = null!;

    public string Lista { get; set; } = null!;

    public string NombreEncontrado { get; set; } = null!;

    public string IdentificacionEncontrada { get; set; } = null!;

    public string DelitoOcausa { get; set; } = null!;

    public string? Alias { get; set; }

    public string Fuente { get; set; } = null!;

    public string? FechaCarga { get; set; }

    public string Ciudad { get; set; } = null!;

    public string? FechaPublicacion { get; set; }

    public string Demandante { get; set; } = null!;

    public string Detalle { get; set; } = null!;

    public virtual RespuestaLaft RespuestaLaft { get; set; } = null!;
}
