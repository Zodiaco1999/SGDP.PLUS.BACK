using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

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
