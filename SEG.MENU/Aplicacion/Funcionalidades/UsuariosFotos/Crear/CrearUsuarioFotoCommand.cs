using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Crear;

public record struct CrearUsuarioFotoCommand(
     string UsuarioId,
     string Foto,
     string Formato) : IRequest<CrearUsuarioFotoResponse>;