namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;

public record struct ConsultarPerfilesResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    string NombreAplicacion,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);
