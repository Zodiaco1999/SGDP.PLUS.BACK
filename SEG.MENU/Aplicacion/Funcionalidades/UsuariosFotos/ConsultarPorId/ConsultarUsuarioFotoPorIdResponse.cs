namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.ConsultarPorId;

public record struct ConsultarUsuarioFotoPorIdResponse(
    string UsuarioId,
    string Foto,
    string Formato,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);