namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

public record struct ActivarInactivarPerfilesResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);