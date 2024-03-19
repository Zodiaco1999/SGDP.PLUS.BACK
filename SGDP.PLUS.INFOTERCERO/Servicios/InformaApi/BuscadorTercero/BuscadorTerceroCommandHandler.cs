using MediatR;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.BuscadorTercero;

public class BuscadorTerceroCommandHandler : IRequestHandler<BuscadorTerceroCommand, List<BuscadorTerceroResponse>>
{
    private readonly IGestionInformaApi _gestionTerceros;
    public BuscadorTerceroCommandHandler(IGestionInformaApi gestionTerceros) => _gestionTerceros = gestionTerceros;

    public async Task<List<BuscadorTerceroResponse>> Handle(BuscadorTerceroCommand request, CancellationToken cancellationToken)
        => await _gestionTerceros.BuscadorTercero(request);
}
