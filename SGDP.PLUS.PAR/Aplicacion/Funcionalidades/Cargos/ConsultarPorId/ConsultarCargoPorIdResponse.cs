namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ConsultarPorId;

public record struct ConsultarCargoPorIdResponse(
    Guid CargoId,
    string? Nombre,
    string? Abreviatura,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );