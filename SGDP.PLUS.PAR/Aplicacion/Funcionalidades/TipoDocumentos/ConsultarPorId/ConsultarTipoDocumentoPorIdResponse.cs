namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ConsultarPorId;

public record struct ConsultarTipoDocumentoPorIdResponse(
    int TipoDocumentoId,
    string Nombre,
    string Abreviatura,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );