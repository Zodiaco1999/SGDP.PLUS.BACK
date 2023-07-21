namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.ConsultarPorId;

public record struct ConsultarModuloPorIdResponse(
    Guid AplicacionId,
    Guid ModuloId,
    string NombreModulo,
    string DescModulo,
    string IconoPrefijo,
    string IconoNombre,
    int Orden,
    bool Activo);