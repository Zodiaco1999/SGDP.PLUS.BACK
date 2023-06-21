using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

public record struct EditarUsuariosFotosCommand(
    string UsuarioId,
    string Foto,
    string Formato) : IRequest<EditarUsuariosFotosResponse>;