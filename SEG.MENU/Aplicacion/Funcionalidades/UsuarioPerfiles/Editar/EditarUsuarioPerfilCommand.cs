using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

public record struct EditarUsuarioPerfilCommand(
    string UsuarioId,
    Guid PerfilId,
    DateTime FechaInicia,
    DateTime FechaTermina) : IRequest<EditarUsuarioPerfilResponse>;