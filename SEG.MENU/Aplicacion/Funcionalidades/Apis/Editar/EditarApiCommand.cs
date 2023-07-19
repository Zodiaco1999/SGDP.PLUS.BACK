using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.Editar;

public record struct EditarApiCommand(
    Guid ApiId,
    string NombreApi,
    string DescripcionApi,
    string UrlPrueba,
    string UrlProduccion) : IRequest;