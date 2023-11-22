using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Crear;

public record struct CrearUsuarioCommand(
    string UsuarioId,
    string? UsuarioDominio,
    int? TipoDocumentoId,
    string? NumeroIdentificacion,
    string PrimerNombre,
    string? SegundoNombre,
    string PrimerApellido,
    string? SegundoApellido,
    string Email,
    string? Foto,
    DateTime? FechaNacimiento,
    string Genero,                
    List<CrearUsuarioPerfilCommand> usuarioPerfiles) : IRequest<CrearUsuarioResponse>;