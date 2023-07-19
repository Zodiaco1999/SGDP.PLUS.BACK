using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ConsultarPorId;

public record struct ConsultarPerfilPorIdResponse(
    Guid PerfilId,
    string NombrePerfil,
    string DescPerfil,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    PerfilMenu? PerfilMenu);
