namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Crear;

    public record struct CrearUsuarioPerfilResponse(
        string UsuarioId,
        Guid PerfilId,
        DateTime? FechaInicia,
        DateTime? FechaTermina);