using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;

public record struct CrearUsuarioPerfilCommand(
    string UsuarioId,
    Guid PerfilId,
    DateTime FechaInicia,
    DateTime FechaTermina): IRequest<CrearUsuarioPerfilResponse>;
