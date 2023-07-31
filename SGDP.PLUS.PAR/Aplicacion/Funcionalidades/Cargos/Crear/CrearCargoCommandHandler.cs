using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Crear;

public class CrearCargoCommandHandler : IRequestHandler<CrearCargoCommand, CrearCargoResponse>
{
    private readonly IGestionCargos _gestionCargos;
    public CrearCargoCommandHandler(IGestionCargos gestionCargos) => _gestionCargos = gestionCargos;

    public async Task<CrearCargoResponse> Handle(CrearCargoCommand request, CancellationToken cancellationToken)
    {
        CrearCargoResponse result = await _gestionCargos.CrearCargo(request);

        return result;
    }
}