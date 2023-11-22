using MediatR;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ActivarInactivar;

public record struct ActivarInactivarPaisCommand(Guid PaisId) : IRequest<ActivarInactivarPaisResponse>;