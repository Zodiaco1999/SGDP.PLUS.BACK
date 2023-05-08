namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

public record struct ActivarInactivarAplicacionesResponse
    (Guid AplicacionId,
    string NombreAplicacion,
    string DescAplicacion,
    string RutaUrl,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);