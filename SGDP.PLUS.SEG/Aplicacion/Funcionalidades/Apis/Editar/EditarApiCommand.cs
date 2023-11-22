using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Editar;

public record struct EditarApiCommand(
    Guid ApiId,
    string NombreApi,
    string DescripcionApi,
    string UrlPrueba,
    string UrlProduccion) : IRequest;