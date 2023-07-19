using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;

public record struct CrearPerfilCommand(string NombrePerfil, string DescPerfil) : IRequest<CrearPerfilResponse>;
