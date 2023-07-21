namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

public record struct EditarUsuarioFotoResponse(
    string UsuarioId,
    string Foto,
    string Formato,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);