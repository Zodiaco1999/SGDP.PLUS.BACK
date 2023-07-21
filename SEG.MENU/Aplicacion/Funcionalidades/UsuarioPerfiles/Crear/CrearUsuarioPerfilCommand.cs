using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;

public record struct CrearUsuarioPerfilCommand(
    string UsuarioId,
    Guid PerfilId,
    DateTime FechaInicia,
    DateTime FechaTermina): IRequest<CrearUsuarioPerfilResponse>;
