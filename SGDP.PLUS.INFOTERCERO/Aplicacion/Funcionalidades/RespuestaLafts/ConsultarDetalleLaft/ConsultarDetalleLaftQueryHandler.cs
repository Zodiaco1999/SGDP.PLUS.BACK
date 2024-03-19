using MediatR;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarDetalleLaft;

public class ConsultarDetalleLaftQueryHandler : IRequestHandler<ConsultarDetalleLaftQuery, IEnumerable<ConsultarDetalleLaftResponse>>
{
    private readonly IGestionRespuestaLafts _gestionRespuestaLafts;
    public ConsultarDetalleLaftQueryHandler(IGestionRespuestaLafts gestionRespuestaLafts) => _gestionRespuestaLafts = gestionRespuestaLafts;

    public async Task<IEnumerable<ConsultarDetalleLaftResponse>> Handle(ConsultarDetalleLaftQuery request, CancellationToken cancellationToken)
        => await _gestionRespuestaLafts.ConsultarDetalleLaft(request);
}
