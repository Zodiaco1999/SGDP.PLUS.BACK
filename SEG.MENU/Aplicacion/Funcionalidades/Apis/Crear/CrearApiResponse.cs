namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.Crear;

public record struct CrearApiResponse(
    Guid AplicacionId,
    Guid ApiId,
    string NombreApi,
    string DescripcionApi,
    string UrlPrueba,
    string UrlProduccion,
    bool Activo);