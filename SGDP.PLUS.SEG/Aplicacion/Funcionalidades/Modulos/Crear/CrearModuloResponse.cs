namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Crear;

public record struct CrearModuloResponse(
    Guid AplicacionId,
    Guid ModuloId,
    string NombreModulo,
    string DescModulo,
    string IconoPrefijo,
    string IconoNombre,
    int Orden,
    bool Activo);
