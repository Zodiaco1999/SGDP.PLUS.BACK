using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public class CrearAplicacionesCommandHandler : IRequestHandler<CrearAplicacionesCommand, CrearAplicacionesResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public CrearAplicacionesCommandHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<CrearAplicacionesResponse> Handle(CrearAplicacionesCommand request, CancellationToken cancellationToken)
    {
        var result = await _gestionAplicaciones.CreaAplicacion(request);

        return result;
    }
}
