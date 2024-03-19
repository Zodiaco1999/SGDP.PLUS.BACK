using MediatR;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.ConsultaLaft;

public class ConsultaLaftCommandHandler : IRequestHandler<ConsultaLaftCommand, ConsultaLaftResponse>
{
    private readonly IGestionInformaApi _gestionTerceros;
    public ConsultaLaftCommandHandler(IGestionInformaApi gestionTerceros) => _gestionTerceros = gestionTerceros;

    public Task<ConsultaLaftResponse> Handle(ConsultaLaftCommand request, CancellationToken cancellationToken)
        => _gestionTerceros.ConsultaLaft(request);
}
