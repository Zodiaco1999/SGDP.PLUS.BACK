namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Crear;

public record struct CrearPerfilResponse(Guid perfilId, string nombrePerfil, string descPerfil, bool activo);
