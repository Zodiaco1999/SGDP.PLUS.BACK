namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Crear;

public record struct CrearCargoResponse(
    Guid CargoId,
    string? Nombre,
    string? Abreviatura,
    bool Avtivo
    );