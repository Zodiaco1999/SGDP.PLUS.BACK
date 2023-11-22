namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Consultar;

public record struct ConsultarTipoPersonasResponse(
    Guid TipoPersonaId,
    string NombreTipo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );