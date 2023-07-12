using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public record struct CrearAplicacionCommand(string NombreAplicacion, string DescAplicacion, string RutaUrl) : IRequest<CrearAplicacionResponse>;
