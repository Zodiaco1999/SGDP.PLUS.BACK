namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Lista;
 public record struct ListaTipoDocumentoResponse(
        int TipoDocumentoId,
        string? Nombre,
        string? Abreviatura,
        bool Activo);
    