namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ActivarInactivar;

public record struct ActivarInactivarTipoPersonaResponse(
    Guid TipoPersonaId,
    string NombreTipo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );