using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Editar;

public class EditarAplicacionesCommandHandler : IRequestHandler<EditarAplicacionesCommand, EditarAplicacionesResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;
    public EditarAplicacionesCommandHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<EditarAplicacionesResponse> Handle(EditarAplicacionesCommand request, CancellationToken cancellationToken)
    {
        EditarAplicacionesResponse result = await _gestionAplicaciones.ActualizaAplicacion(request!);

        return result;
    }
}
