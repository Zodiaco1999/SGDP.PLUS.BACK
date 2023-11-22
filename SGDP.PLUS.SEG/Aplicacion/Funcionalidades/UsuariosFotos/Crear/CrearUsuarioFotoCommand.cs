using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Crear;

public record struct CrearUsuarioFotoCommand(
     string UsuarioId,
     string Foto,
     string Formato) : IRequest<CrearUsuarioFotoResponse>;