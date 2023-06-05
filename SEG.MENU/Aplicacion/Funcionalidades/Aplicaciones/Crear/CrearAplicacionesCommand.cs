using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public record struct CrearAplicacionesCommand(string NombreAplicacion, string DescAplicacion, string RutaUrl) : IRequest<CrearAplicacionesResponse>;
