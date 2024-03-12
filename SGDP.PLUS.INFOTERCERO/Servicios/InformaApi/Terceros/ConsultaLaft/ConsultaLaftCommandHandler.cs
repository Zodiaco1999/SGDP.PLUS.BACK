using MediatR;
using SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Servicios.InformaApi.Terceros.ConsultaLaft;

public class ConsultaLaftCommandHandler : IRequestHandler<ConsultaLaftCommand, ConsultaLaftResponse>
{
    private readonly IGestionTerceros _gestionTerceros;
    public ConsultaLaftCommandHandler(IGestionTerceros gestionTerceros) => _gestionTerceros = gestionTerceros;

    public Task<ConsultaLaftResponse> Handle(ConsultaLaftCommand request, CancellationToken cancellationToken)
        => _gestionTerceros.ConsultaLaft(request);
}
