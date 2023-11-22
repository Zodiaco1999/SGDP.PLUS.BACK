using MediatR;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ObtenerInforme;

public class ObtenerInformeCommandHandler : IRequestHandler<ObtenerInformeCommand, ObtenerInformeResponse>
{
    private readonly IGestionTerceros _gestionTerceros;
    public ObtenerInformeCommandHandler(IGestionTerceros gestionTerceros) => _gestionTerceros = gestionTerceros;

    public async Task<ObtenerInformeResponse> Handle(ObtenerInformeCommand request, CancellationToken cancellationToken)
        => await _gestionTerceros.ObtenerInforme(request);
}
