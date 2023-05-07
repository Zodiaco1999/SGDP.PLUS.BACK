using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public record struct CrearAplicacionesCommand(string nombreAplicacion, string descAplicacion, string rutaUrl) : IRequest<CrearAplicacionesResponse>;
