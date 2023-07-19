using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public class CrearAplicacionCommandHandler : IRequestHandler<CrearAplicacionCommand, CrearAplicacionResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public CrearAplicacionCommandHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<CrearAplicacionResponse> Handle(CrearAplicacionCommand request, CancellationToken cancellationToken)
    {
        var result = await _gestionAplicaciones.CrearAplicacion(request);

        return result;
    }
}
