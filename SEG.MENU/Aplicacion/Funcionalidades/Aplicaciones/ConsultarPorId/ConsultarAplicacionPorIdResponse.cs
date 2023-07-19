using SEG.MENU.Aplicacion.Funcionalidades.Apis.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Modulos.Crear;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;

public record struct ConsultarAplicacionPorIdResponse(
    Guid AplicacionId,
    string NombreAplicacion,
    string DescAplicacion,
    string RutaUrl,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    IEnumerable<CrearModuloResponse> ListaModulos,
    IEnumerable<CrearApiResponse> ListaApis);