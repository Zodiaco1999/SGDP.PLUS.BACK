namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Consultar;

public record struct ConsultarCargosResponse(
    Guid CargoId,
    string? Nombre,
    string? Abreviatura,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );