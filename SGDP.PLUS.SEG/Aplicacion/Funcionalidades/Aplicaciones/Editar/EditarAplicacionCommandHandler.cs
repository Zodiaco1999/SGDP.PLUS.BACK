using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Editar;

public class EditarAplicacionCommandHandler : IRequestHandler<EditarAplicacionCommand, EditarAplicacionResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;
    public EditarAplicacionCommandHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<EditarAplicacionResponse> Handle(EditarAplicacionCommand request, CancellationToken cancellationToken)
    {
        EditarAplicacionResponse result = await _gestionAplicaciones.EditarAplicacion(request!);

        return result;
    }
}
