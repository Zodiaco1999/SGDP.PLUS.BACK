namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Consultar;

public record struct ConsultarPerfilesResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);
