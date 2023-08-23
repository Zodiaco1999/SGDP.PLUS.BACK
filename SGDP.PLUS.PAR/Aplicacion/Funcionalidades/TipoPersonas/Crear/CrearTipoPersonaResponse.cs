namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Crear;

public record struct CrearTipoPersonaResponse(
    Guid TipoPersonaId,
    string? NombreTipo,
    bool activo
    );