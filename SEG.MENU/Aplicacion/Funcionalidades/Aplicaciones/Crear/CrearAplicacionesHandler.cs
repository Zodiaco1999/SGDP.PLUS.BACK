using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public class CrearAplicacionesHandler : IRequestHandler<CrearAplicacionesCommand, CrearAplicacionesResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public CrearAplicacionesHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<CrearAplicacionesResponse> Handle(CrearAplicacionesCommand request, CancellationToken cancellationToken)
    {
        var registroAplicacion = Aplication.CrearRegistro(request.nombreAplicacion, request.descAplicacion, request.rutaUrl);
        var result = await _gestionAplicaciones.CreaAplicacion(registroAplicacion);

        return result;
    }
}
