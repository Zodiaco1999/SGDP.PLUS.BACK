namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Editar;

public record struct EditarTipoPersonaResponse(
    Guid TipoPersonaId,
    string NombreTipo,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );