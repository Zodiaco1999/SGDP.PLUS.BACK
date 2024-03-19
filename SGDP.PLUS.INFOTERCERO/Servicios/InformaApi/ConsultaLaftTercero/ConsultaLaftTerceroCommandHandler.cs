using MediatR;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaftTercero;

public class ConsultaLaftTerceroCommandHandler : IRequestHandler<ConsultaLaftTerceroCommand, ConsultaLaftTerceroResponse>
{
    private readonly IGestionInformaApi _gestionTerceros;
    public ConsultaLaftTerceroCommandHandler(IGestionInformaApi gestionTerceros) => _gestionTerceros = gestionTerceros;

    public Task<ConsultaLaftTerceroResponse> Handle(ConsultaLaftTerceroCommand request, CancellationToken cancellationToken)
        => _gestionTerceros.ConsultaLaftTercero(request);
}
