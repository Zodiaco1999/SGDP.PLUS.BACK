using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Editar;

public record struct EditarUsuarioCommand(
    string UsuarioId,
    Guid PerfilId,
    string? UsuarioDominio,
    int? TipoDocumentoId,
    string? NumeroIdentificacion,
    string PrimerNombre,
    string? SegundoNombre,
    string PrimerApellido,
    string? SegundoApellido,
    string Email,
    DateTime? FechaNacimiento,
    string? Foto,
    string Genero,
    string? Contrasena,
    DateTime FechaActualizacionContrasena,
    short? AccesosFallidos,
    DateTime? FechaBloqueo,
    string? CodigoAsignacion,
    DateTime? VenceCodigoAsignacion,
    List<EditarUsuarioPerfilCommand> usuarioPerfiles) : IRequest<EditarUsuarioResponse>;