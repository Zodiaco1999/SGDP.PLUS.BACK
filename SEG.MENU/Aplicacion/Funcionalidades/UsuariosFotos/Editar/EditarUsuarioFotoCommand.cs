using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

public record struct EditarUsuarioFotoCommand(
    string UsuarioId,
    string Foto,
    string Formato) : IRequest<EditarUsuarioFotoResponse>;