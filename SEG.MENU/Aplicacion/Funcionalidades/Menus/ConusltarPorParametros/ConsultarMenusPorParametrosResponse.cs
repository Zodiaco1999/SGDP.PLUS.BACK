namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;

public record struct ConsultarMenusPorParametrosResponse(
    Guid AplicacionId,
    Guid ModuloId,
    Guid MenuId,
    string NombreMenu,
    string EtiquetaMenu,
    string DescMenu,
    string Url,
    short Orden,
    bool MenuConsulta,
    bool MenuInserta,
    bool MenuActualiza,
    bool MenuElimina,
    bool MenuActiva,
    bool MenuEjecuta);