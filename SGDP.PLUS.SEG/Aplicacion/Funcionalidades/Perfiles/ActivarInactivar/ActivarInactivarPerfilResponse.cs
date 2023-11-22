namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

public record struct ActivarInactivarPerfilResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);