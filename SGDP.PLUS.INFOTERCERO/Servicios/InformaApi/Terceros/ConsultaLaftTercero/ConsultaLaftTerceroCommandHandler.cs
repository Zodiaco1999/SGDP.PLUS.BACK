using MediatR;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaftTercero;

public class ConsultaLaftTerceroCommandHandler : IRequestHandler<ConsultaLaftTerceroCommand, ConsultaLaftTerceroResponse>
{
    private readonly IGestionTerceros _gestionTerceros;
    public ConsultaLaftTerceroCommandHandler(IGestionTerceros gestionTerceros) => _gestionTerceros = gestionTerceros;

    public Task<ConsultaLaftTerceroResponse> Handle(ConsultaLaftTerceroCommand request, CancellationToken cancellationToken)
        => _gestionTerceros.ConsultaLaftTercero(request);
}
