namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConsultarPorId;

public record struct ConsultarMenuPorIdResponse(
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
    bool Ejecuta,
    bool Activo,
    string CreaUsuario,
    DateTime CreaFecha,
    string ModificaUsuario,
    DateTime ModificaFecha);