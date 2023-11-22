namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuarioPerfiles.Consultar;

    public record struct ConsultarUsuariosPerfilResponse(
        string UsuarioId,
        Guid PerfilId,
        string NombrePerfil,
        string NombreAplicacion,
        DateTime? FechaInicia,
        DateTime? FechaTermina,
        string CreaUsuario,
        DateTime CreaFecha,
        string ModificaUsuario,
        DateTime ModificaFecha);