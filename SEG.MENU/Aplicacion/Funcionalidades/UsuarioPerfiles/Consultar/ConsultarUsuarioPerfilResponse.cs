namespace SEG.MENU.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

    public record struct ConsultarUsuarioPerfilResponse(
        string UsuarioId,
        Guid PerfilId,
        DateTime FechaInicia,
        DateTime FechaTermina,
        string CreaUsuario,
        DateTime CreaFecha,
        string ModificaUsuario,
        DateTime ModificaFecha);