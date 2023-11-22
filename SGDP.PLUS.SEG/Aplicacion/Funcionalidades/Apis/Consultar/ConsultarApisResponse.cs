namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Consultar;

public record struct ConsultarApisResponse(
    Guid AplicacionId,
    Guid ApiId,
    string NombreApi,
    string DescripcionApi,
    string UrlPrueba,
    string UrlProduccion,
    bool Activo);