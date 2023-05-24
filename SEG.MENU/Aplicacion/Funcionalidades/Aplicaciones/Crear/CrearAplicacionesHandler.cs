using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SEG.MENU.Aplicacion.Interfaces;
using SEG.MENU.Dominio.Entidades;
using System.Runtime.InteropServices;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public class CrearAplicacionesHandler : IRequestHandler<CrearAplicacionesCommand, CrearAplicacionesResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public CrearAplicacionesHandler(IGestionAplicaciones gestionAplicaciones)
    {
        _gestionAplicaciones = gestionAplicaciones;
    }

    public async Task<CrearAplicacionesResponse> Handle(CrearAplicacionesCommand request, CancellationToken cancellationToken)
    {
        var registroAplicacion = Aplication.CrearRegistro(request.nombreAplicacion, request.descAplicacion, request.rutaUrl);
        await _gestionAplicaciones.CreaAplicacion(registroAplicacion);

        CrearAplicacionesResponse crearAplicacionesResponse = new CrearAplicacionesResponse(registroAplicacion.AplicacionId, registroAplicacion.NombreAplicacion, registroAplicacion.DescAplicacion, registroAplicacion.RutaUrl, registroAplicacion.Activo);

        return crearAplicacionesResponse;
    }
}
