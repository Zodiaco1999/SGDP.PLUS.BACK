namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;

public record struct ConsultarAplicacionPorIdResponse(
    Guid AplicacionId,
    string NombreAplicacion,
    string DescAplicacion,
    string RutaUrl,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);