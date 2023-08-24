namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Consultar;

public record struct ConsultarModulosResponse(
    Guid AplicacionId,
    Guid ModuloId,
    string NombreModulo,
    string DescModulo,
    string IconoPrefijo,
    string IconoNombre,
    int Orden,
    bool Activo);