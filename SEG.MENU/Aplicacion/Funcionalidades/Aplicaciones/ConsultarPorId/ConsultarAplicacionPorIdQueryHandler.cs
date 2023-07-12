using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ConsultarPorId;

public class ConsultarAplicacionPorIdQueryHandler : IRequestHandler<ConsultarAplicacionPorIdQuery, ConsultarAplicacionPorIdResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public ConsultarAplicacionPorIdQueryHandler(IGestionAplicaciones gestionAplicaciones)
    {
        _gestionAplicaciones = gestionAplicaciones;
    }

    public async Task<ConsultarAplicacionPorIdResponse> Handle(ConsultarAplicacionPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarAplicacionPorIdResponse res = await _gestionAplicaciones.ConsultarAplicacionPorId(request.AplicacionId);

        return res;
    }
}