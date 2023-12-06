using MediatR;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaft;

public class ConsultaLaftCommandHandler : IRequestHandler<ConsultaLaftCommand, ConsultaLaftResponse>
{
    private readonly IGestionTerceros _gestionTerceros;
    public ConsultaLaftCommandHandler(IGestionTerceros gestionTerceros) => _gestionTerceros = gestionTerceros;

    public Task<ConsultaLaftResponse> Handle(ConsultaLaftCommand request, CancellationToken cancellationToken)
        => _gestionTerceros.ConsultaLaft(request);
}
