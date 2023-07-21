namespace SEG.MENU.Aplicacion.Funcionalidades.Usuarios.ConsultarPorId;

public record struct ConsultarUsuarioPorIdResponse(
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
    DateTime? VenceCodigoAsignacion,
    bool? LogearLdap,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);