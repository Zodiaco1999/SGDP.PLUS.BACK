namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Crear;

public record struct CrearTipoDocumentoResponse(
    int TipoDocumentoId,
    string? Nombre,
    string? Abreviatura,
    bool activo
    );