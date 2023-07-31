using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ActivarInactivar;

public record struct ActivarInactivarCargoCommand(Guid CargoId) : IRequest<ActivarInactivarCargoResponse>;