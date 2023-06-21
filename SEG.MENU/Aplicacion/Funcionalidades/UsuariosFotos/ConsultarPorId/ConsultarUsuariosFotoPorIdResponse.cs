namespace SEG.MENU.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

public record struct ConsultarUsuariosFotoPorIdResponse(
    string UsuarioId,
    string Foto,
    string Formato,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);