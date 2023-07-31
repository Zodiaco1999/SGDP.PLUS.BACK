namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ActivarInactivar;

public record struct ActivarInactivarCargoResponse(
    Guid CargoID,
    string? Nombre,
    string? Abreviatura,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );