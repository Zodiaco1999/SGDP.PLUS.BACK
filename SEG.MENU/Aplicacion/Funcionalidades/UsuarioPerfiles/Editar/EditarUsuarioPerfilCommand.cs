using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

public record struct EditarUsuarioPerfilCommand(
    string UsuarioId,
    Guid PerfilId,
    DateTime FechaInicia,
    DateTime FechaTermina) : IRequest<EditarUsuarioPerfilResponse>;