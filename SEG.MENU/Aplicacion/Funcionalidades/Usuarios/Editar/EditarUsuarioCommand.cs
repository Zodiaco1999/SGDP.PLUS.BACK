using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Editar;

public record struct EditarUsuarioCommand(
    string UsuarioId,
    string? UsuarioDominio,
    int? TipoDocumentoId,
    string? NumeroIdentificacion,
    string PrimerNombre,
    string? SegundoNombre,
    string PrimerApellido,
    string? SegundoApellido,
    string Email,
    DateTime? FechaNacimiento,
    string Genero,
    string? Contrasena,
    DateTime FechaActualizacionContrasena,
    short? AccesosFallidos,
    DateTime? FechaBloqueo,
    string? CodigoAsignacion,
    DateTime? VenceCodigoAsignacion) : IRequest<EditarUsuarioResponse>;