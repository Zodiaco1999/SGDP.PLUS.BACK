using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Editar;

public record struct EditarCargoCommand(
    Guid CargoId,
    string? Nombre,
    string? Abreviatura
    ) : IRequest<EditarCargoResponse>;