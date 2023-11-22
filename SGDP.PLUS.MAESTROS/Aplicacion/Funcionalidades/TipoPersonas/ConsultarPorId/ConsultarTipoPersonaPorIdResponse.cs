namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ConsultarPorId;

public record struct ConsultarTipoPersonaPorIdResponse(
    Guid TipoPersonaId,
    string NombreTipo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );