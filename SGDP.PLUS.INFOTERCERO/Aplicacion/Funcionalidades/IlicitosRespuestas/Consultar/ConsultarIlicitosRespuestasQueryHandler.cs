using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.IlicitosRespuestas.Consultar;

public class ConsultarIlicitosRespuestasQueryHandler : IRequestHandler<ConsultarIlicitosRespuestasQuery, DataViewModel<ConsultarIlicitosRespuestasResponse>>
{
    private readonly IGestionIlicitosRespuestas _gestionIlicitosRespuestas;
    public ConsultarIlicitosRespuestasQueryHandler(IGestionIlicitosRespuestas gestionIlicitosRespuestas) => _gestionIlicitosRespuestas = gestionIlicitosRespuestas;

    public async Task<DataViewModel<ConsultarIlicitosRespuestasResponse>> Handle(ConsultarIlicitosRespuestasQuery request, CancellationToken cancellationToken)
        => await _gestionIlicitosRespuestas.ConsultarIlicitosRespuestas(request);
}