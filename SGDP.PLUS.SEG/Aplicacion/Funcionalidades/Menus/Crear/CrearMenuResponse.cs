namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.Crear;

public record struct CrearMenuResponse(
    Guid AplicacionId,
    Guid ModuloId,
    Guid MenuId,
    string NombreMenu,
    string EtiquetaMenu,
    string DescMenu,
    string Url,
    short Orden,
    bool Consulta,
    bool Inserta,
    bool Actualiza,
    bool Elimina,
    bool Activa,
    bool Ejecuta);