using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.ConsultarPorId;

public class ConsultarIlicitosRespuestaPorIdQueryHandler : IRequestHandler<ConsultarIlicitosRespuestaPorIdQuery, DataViewModel<ConsultarIlicitosRespuestaPorIdResponse>>
{
    private readonly IGestionIlicitosRespuestas _gestionIlicitosRespuestas;
    public ConsultarIlicitosRespuestaPorIdQueryHandler(IGestionIlicitosRespuestas gestionIlicitosRespuestas) => _gestionIlicitosRespuestas = gestionIlicitosRespuestas;

    public async Task<DataViewModel<ConsultarIlicitosRespuestaPorIdResponse>> Handle(ConsultarIlicitosRespuestaPorIdQuery request, CancellationToken cancellationToken)
        => await _gestionIlicitosRespuestas.ConsultarIlicitosRespuestaPorId(request);
}