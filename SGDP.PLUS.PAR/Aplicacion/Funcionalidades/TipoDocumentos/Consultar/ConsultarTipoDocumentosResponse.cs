namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Consultar;

public record struct ConsultarTipoDocumentosResponse(
    int TipoDocumentoId,
    string Nombre,
    string Abreviatura,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );