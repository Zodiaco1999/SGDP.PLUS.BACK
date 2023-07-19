using MediatR;

namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.Crear;

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
                        DateTime? FechaNacimiento,
                        string Genero,
                        string? Contrasena,
                        DateTime FechaActualizacionContrasena,
                        short? AccesosFallidos,
                        DateTime? FechaBloqueo,
                        string? CodigoAsignacion,
                        DateTime? VenceCodigoAsignacion) : IRequest<CrearUsuarioResponse>;