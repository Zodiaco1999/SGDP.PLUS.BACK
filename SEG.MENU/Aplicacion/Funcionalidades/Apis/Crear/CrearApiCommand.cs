using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.Crear;

public record struct CrearApiCommand(
    Guid AplicacionId,
    string NombreApi,
    string DescripcionApi,
    string UrlPrueba,
    string UrlProduccion) : IRequest<CrearApiResponse>;