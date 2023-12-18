using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

public class InfoBasica : CamposLog
{
    public string Nit { get; set; } = null!;

    public string Ici { get; set; } = null!;

    public string IdFiscal { get; set; } = null!;

    public DateTime FechaConstitucion { get; set; }

    public string? Email { get; set; }

    public string FormaJuridicaCod { get; set; } = null!;

    public string Actividad { get; set; } = null!;

    public string Denominacion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string DomicilioSocial { get; set; } = null!;

    public string Telefono { get; set; } = null!;
}
