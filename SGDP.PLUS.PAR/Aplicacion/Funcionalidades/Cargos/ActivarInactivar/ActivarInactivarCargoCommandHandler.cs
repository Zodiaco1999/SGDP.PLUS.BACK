using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ActivarInactivar;

public class ActivarInactivarCargoCommandHandler : IRequestHandler<ActivarInactivarCargoCommand, ActivarInactivarCargoResponse>
{
    private readonly IGestionCargos _gestionCargos;
    public ActivarInactivarCargoCommandHandler(IGestionCargos gestionCargos) => _gestionCargos = gestionCargos;

    public async Task<ActivarInactivarCargoResponse> Handle(ActivarInactivarCargoCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarCargoResponse result = await _gestionCargos.ActivarInactivarCargo(request.CargoId);

        return result;
    }
}