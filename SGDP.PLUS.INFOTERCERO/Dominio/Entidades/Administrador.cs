using SGDP.PLUS.Comun.General;

namespace SGDP.PLUS.INFOTERCERO.Dominio.Entidades;

public partial class Administrador : Entity
{
    public Guid AdministradorId { get; set; }

    public string NitTercero { get; set; } = null!;

    public DateTime FechaSolicitud { get; set; }

    public string? Cedula { get; set; }

    public string? Nombre { get; set; }

    public string? Cargo { get; set; }

    public string? CodigoCargo { get; set; }

    public string? FechaNombramiento { get; set; }

    public string? FechaCambioAdmin { get; set; }

    public virtual InfoBasica InfoBasica { get; set; } = null!;
}
