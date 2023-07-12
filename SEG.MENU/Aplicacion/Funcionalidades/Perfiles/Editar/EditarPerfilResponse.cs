namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;

public record struct EditarPerfilResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);