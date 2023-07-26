namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;

public record struct EditarTipoDocumentoResponse(
    int TipoDocumentoId,
    string Nombre,
    string Abreviatura,
    string ModificaUsuario,
    DateTime ModificaFecha,
    bool Activo
    );