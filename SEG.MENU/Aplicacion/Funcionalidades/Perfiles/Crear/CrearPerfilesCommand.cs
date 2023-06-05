using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;

public record struct CrearPerfilesCommand(string NombrePerfil, string DescPerfil) : IRequest<CrearPerfilesResponse>;
