namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;

public record struct ConsultarPerfilPorIdResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    Guid AplicacionId,
    string NombreAplicacion,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);
