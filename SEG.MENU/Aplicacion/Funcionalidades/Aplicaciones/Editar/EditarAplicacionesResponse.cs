namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;

public record struct EditarAplicacionesResponse
    (Guid AplicacionId,
    string NombreAplicacion,
    string DescAplicacion,
    string RutaUrl,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);