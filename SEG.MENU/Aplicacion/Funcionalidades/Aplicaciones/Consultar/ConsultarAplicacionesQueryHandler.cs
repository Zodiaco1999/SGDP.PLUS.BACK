using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Consultar;

public class ConsultarAplicacionesQueryHandler : IRequestHandler<ConsultarAplicacionesQuery, DataViewModel<ConsultarAplicacionesResponse>>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public ConsultarAplicacionesQueryHandler(IGestionAplicaciones gestionAplicaciones)
    {
        _gestionAplicaciones = gestionAplicaciones;
    }

    public async Task<DataViewModel<ConsultarAplicacionesResponse>> Handle(ConsultarAplicacionesQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarAplicacionesResponse> res = await _gestionAplicaciones.ConsultarAplicaciones(request.textoBusqueda, request.pagina, request.registrosPorPagina);
        return res;        
    }
}
