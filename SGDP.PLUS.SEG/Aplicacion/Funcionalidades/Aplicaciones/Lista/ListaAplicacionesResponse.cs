namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Lista;

public record struct ListaAplicacionesResponse(
    Guid AplicacionId,
    string NombreAplicacion,
    string DescAplicacion,
    string RutaUrl,
    bool Activo);