using SGDP.PLUS.Comun.Excepcion;
using SGDP.PLUS.Comun.Entidades;

namespace SGDP.PLUS.SEG.Dominio.Entidades;

public class Aplication : CamposLog
{
    public Guid AplicacionId { get; set; } = Guid.NewGuid();
    public string NombreAplicacion { get; set; } = null!;
    public string DescAplicacion { get; set; } = null!;
    public string RutaUrl { get; set; } = null!;
    public bool Activo { get; set; } = true;

    public List<Api> Apis { get; set; } = new();
    public List<Modulo> Modulos { get; set; } = new();
}
