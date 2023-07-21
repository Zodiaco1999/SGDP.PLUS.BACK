using MediatR;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Editar;

public record struct EditarModuloCommand(
    Guid ModuloId,
    string NombreModulo,
    string DescModulo,
    string IconoPrefijo,
    string IconoNombre,
    int Orden) : IRequest;