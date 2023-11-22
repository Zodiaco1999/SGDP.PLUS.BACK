using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Editar;

public record struct EditarAplicacionCommand
    (Guid AplicacionId,
    string NombreAplicacion,
    string DescAplicacion,
    string RutaUrl) : IRequest<EditarAplicacionResponse>;