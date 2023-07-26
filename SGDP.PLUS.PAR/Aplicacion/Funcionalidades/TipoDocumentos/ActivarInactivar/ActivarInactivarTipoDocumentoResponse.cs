namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ActivarInactivar;

public record struct ActivarInactivarTipoDocumentoResponse(
    int TipoDocumentoId,
    string Nombre,
    string Abreviatura,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );