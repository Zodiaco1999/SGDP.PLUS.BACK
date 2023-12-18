using MediatR;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.Terceros.ConsultaLaftTercero;

public class ConsultaLaftTerceroCommandHandler : IRequestHandler<ConsultaLaftTerceroCommand, ConsultaLaftTerceroResponse>
{
    private readonly IGestionTerceros _gestionTerceros;
    public ConsultaLaftTerceroCommandHandler(IGestionTerceros gestionTerceros) => _gestionTerceros = gestionTerceros;

    public Task<ConsultaLaftTerceroResponse> Handle(ConsultaLaftTerceroCommand request, CancellationToken cancellationToken)
        => _gestionTerceros.ConsultaLaftTercero(request);
}
