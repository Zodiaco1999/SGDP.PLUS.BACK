using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.ConsultarPorNit;

public class ConsultarRespuestaLaftPorNitQueryHandler : IRequestHandler<ConsultarRespuestaLaftPorNitQuery, DataViewModel<ConsultarRespuestaLaftPorNitResponse>>
{
    private readonly IGestionRespuestaLafts _gestionRespuestaLafts;
    public ConsultarRespuestaLaftPorNitQueryHandler(IGestionRespuestaLafts gestionRespuestaLafts) => _gestionRespuestaLafts = gestionRespuestaLafts;

    public async Task<DataViewModel<ConsultarRespuestaLaftPorNitResponse>> Handle(ConsultarRespuestaLaftPorNitQuery request, CancellationToken cancellationToken)
        => await _gestionRespuestaLafts.ConsultarRespuestaLaftPorNit(request.Query, request.Nit, request.Actualiza);

}