namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.Consultar;

public record struct ConsultarUsuariosFotosResponse(
    string UsuarioId,
    string Foto,
    string Formato,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);