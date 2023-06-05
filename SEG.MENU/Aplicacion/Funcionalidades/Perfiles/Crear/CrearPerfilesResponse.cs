namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;

public record struct CrearPerfilesResponse(Guid perfilId, string nombrePerfil, string descPerfil, bool activo);
