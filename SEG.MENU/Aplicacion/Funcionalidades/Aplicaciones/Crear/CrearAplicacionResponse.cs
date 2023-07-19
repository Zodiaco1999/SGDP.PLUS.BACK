namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public record struct CrearAplicacionResponse(Guid AplicacionId, string nombreAplicacion, string descAplicacion, string rutaUrl, bool Activo);