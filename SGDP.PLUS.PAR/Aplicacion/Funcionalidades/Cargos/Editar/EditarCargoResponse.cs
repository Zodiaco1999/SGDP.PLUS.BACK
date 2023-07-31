namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Editar;

public record struct EditarCargoResponse(
    Guid CargoId,
    string? Nombre,
    string? Abreviatura,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );