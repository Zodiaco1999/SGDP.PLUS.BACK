using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

public class ActivarInactivarAplicacionCommandHandler : IRequestHandler<ActivarInactivarAplicacionCommand, ActivarInactivarAplicacionResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;
    public ActivarInactivarAplicacionCommandHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<ActivarInactivarAplicacionResponse> Handle(ActivarInactivarAplicacionCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarAplicacionResponse result = await _gestionAplicaciones.ActivarInactivarAplicacion(request.AplicacionId);

        return result;
    }
}
