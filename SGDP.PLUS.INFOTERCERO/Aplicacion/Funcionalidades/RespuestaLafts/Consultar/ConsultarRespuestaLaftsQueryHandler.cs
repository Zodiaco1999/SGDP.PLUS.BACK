using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Consultar;

public class ConsultarRespuestaLaftsQueryHandler : IRequestHandler<ConsultarRespuestaLaftsQuery, DataViewModel<ConsultarRespuestaLaftsResponse>>
{
    private readonly IGestionRespuestaLafts _gestionRespuestaLafts;
    public ConsultarRespuestaLaftsQueryHandler(IGestionRespuestaLafts gestionRespuestaLafts) => _gestionRespuestaLafts = gestionRespuestaLafts;

    public async Task<DataViewModel<ConsultarRespuestaLaftsResponse>> Handle(ConsultarRespuestaLaftsQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarRespuestaLaftsResponse> result = await _gestionRespuestaLafts.ConsultarRespuestaLafts(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}