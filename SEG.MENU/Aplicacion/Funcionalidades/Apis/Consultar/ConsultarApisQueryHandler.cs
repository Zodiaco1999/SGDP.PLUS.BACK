using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Consultar;

public class ConsultarApisQueryHandler : IRequestHandler<ConsultarApisQuery, IEnumerable<ConsultarApisResponse>>
{
    private readonly IGestionApis _gestionApis;
    public ConsultarApisQueryHandler(IGestionApis gestionApis) => _gestionApis = gestionApis;

    public async Task<IEnumerable<ConsultarApisResponse>> Handle(ConsultarApisQuery request, CancellationToken cancellationToken)
        => await _gestionApis.ConsultarApis(request.AplicacionId);
}
