using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Crear;

public record struct CrearUsuariosFotosCommand(
     string UsuarioId,
     string Foto,
     string Formato) : IRequest<CrearUsuariosFotosResponse>;