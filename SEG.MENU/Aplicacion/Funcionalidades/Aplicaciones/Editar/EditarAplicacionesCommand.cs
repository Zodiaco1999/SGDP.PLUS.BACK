using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;

public record struct EditarAplicacionesCommand
    (Guid AplicacionId,
    string NombreAplicacion,
    string DescAplicacion,
    string RutaUrl) : IRequest<EditarAplicacionesResponse>;