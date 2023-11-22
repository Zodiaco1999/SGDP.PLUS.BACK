namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Seguridad.Entidades;

public record struct UserLogin(
    string UsuarioId,
    string Email,
    string PrimerNombre,
    string PrimerApellido,
    string Genero);