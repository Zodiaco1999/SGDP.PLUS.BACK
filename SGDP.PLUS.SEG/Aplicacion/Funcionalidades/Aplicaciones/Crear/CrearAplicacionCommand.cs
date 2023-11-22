using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public record struct CrearAplicacionCommand(string NombreAplicacion, string DescAplicacion, string RutaUrl) : IRequest<CrearAplicacionResponse>;
