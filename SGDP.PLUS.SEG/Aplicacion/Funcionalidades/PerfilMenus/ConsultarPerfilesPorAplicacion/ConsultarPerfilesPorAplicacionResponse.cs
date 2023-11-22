namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPerfilesPorApp;

public record struct ConsultarPerfilesPorAplicacionResponse(
    Guid AplicacionId,
    Guid PerfilId,
    string NombreAplicacion,
    string NombrePerfil);
