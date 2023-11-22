using MediatR;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.BuscadorTercero;

public class BuscadorTerceroCommandHandler : IRequestHandler<BuscadorTerceroCommand, List<BuscadorTerceroResponse>>
{
    private readonly IGestionTerceros _gestionTerceros;
    public BuscadorTerceroCommandHandler(IGestionTerceros gestionTerceros) => _gestionTerceros = gestionTerceros;

    public async Task<List<BuscadorTerceroResponse>> Handle(BuscadorTerceroCommand request, CancellationToken cancellationToken)
        => await _gestionTerceros.BuscadorTercero(request);
}
