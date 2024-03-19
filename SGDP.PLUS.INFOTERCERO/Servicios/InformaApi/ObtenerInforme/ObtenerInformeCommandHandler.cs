using MediatR;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ObtenerInforme;

public class ObtenerInformeCommandHandler : IRequestHandler<ObtenerInformeCommand, ObtenerInformeResponse>
{
    private readonly IGestionInformaApi _gestionTerceros;
    public ObtenerInformeCommandHandler(IGestionInformaApi gestionTerceros) => _gestionTerceros = gestionTerceros;

    public async Task<ObtenerInformeResponse> Handle(ObtenerInformeCommand request, CancellationToken cancellationToken)
        => await _gestionTerceros.ObtenerInforme(request);
}
