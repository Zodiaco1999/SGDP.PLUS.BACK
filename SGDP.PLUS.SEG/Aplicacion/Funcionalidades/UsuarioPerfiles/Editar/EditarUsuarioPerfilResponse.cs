namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Editar;

public record struct EditarUsuarioPerfilResponse(
        string UsuarioId,
        Guid PerfilId,
        DateTime FechaInicia,
        DateTime FechaTermina,
        string CreaUsuario,
        DateTime CreaFecha,
        string ModificaUsuario,
        DateTime ModificaFecha);

