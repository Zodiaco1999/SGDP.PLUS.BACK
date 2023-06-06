using Ardalis.GuardClauses;
using SEG.Comun.Entidades;

namespace SEG.MENU.Dominio.Entidades;

public class Aplication : CamposLog
{
    public Guid AplicacionId { get; set; } = Guid.NewGuid();
    public string NombreAplicacion { get; set; } = null!;
    public string DescAplicacion { get; set; } = string.Empty;
    public string RutaUrl { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;
    public List<Modulo> Modulos { get; set; } = new();
}
