using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Crear;

public record struct CrearApiCommand(
    Guid AplicacionId,
    string NombreApi,
    string DescripcionApi,
    string UrlPrueba,
    string UrlProduccion) : IRequest<CrearApiResponse>;