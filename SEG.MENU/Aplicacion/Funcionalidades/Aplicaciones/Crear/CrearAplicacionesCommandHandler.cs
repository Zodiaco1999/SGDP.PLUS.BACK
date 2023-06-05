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
        var registroAplicacion = Aplication.CrearRegistro(request.NombreAplicacion, request.DescAplicacion, request.RutaUrl);
        var result = await _gestionAplicaciones.CreaAplicacion(registroAplicacion);

        return result;
    }
}
