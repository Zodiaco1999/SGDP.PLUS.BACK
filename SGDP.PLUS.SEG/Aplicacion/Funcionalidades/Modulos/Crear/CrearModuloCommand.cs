using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Crear;

public record struct CrearModuloCommand(
    Guid AplicacionId,
    string NombreModulo,
    string DescModulo,
    string IconoPrefijo,
    string IconoNombre,
    int Orden) : IRequest<CrearModuloResponse>;