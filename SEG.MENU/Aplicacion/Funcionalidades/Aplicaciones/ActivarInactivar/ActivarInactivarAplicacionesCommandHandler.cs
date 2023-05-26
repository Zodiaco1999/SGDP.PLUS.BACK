using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.ActivarInactivar;

public class ActivarInactivarAplicacionesCommandHandler : IRequestHandler<ActivarInactivarAplicacionesCommand, ActivarInactivarAplicacionesResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;
    public ActivarInactivarAplicacionesCommandHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<ActivarInactivarAplicacionesResponse> Handle(ActivarInactivarAplicacionesCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarAplicacionesResponse result = await _gestionAplicaciones.ActivarInactivar(request.AplicacionId);

        return result;
    }
}
