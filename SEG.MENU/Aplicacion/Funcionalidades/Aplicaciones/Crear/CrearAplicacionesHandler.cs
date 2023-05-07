using MediatR;
using SEG.MENU.Aplicacion.Interfaces;
using SEG.MENU.Dominio.Entidades;
using System.Runtime.InteropServices;

namespace SEG.MENU.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public class CrearAplicacionesHandler : IRequestHandler<CrearAplicacionesCommand, CrearAplicacionesResponse>
{
    private readonly ISeguridadCommandDBContext _seguridadCommandDBContext;

    public CrearAplicacionesHandler(ISeguridadCommandDBContext seguridadCommandDBContext)
    {
        _seguridadCommandDBContext = seguridadCommandDBContext;
    }

    public async Task<CrearAplicacionesResponse> Handle(CrearAplicacionesCommand request, CancellationToken cancellationToken)
    {
        var registroAplicacion = Aplication.CrearRegistro(request.nombreAplicacion, request.descAplicacion, request.rutaUrl);

        _seguridadCommandDBContext.Aplicaciones.Add(registroAplicacion);
        await _seguridadCommandDBContext.SaveChangesAsync(cancellationToken);

        CrearAplicacionesResponse crearAplicacionesResponse = new CrearAplicacionesResponse(registroAplicacion.AplicacionId, registroAplicacion.NombreAplicacion, registroAplicacion.DescAplicacion, registroAplicacion.RutaUrl, registroAplicacion.Activo);

        return crearAplicacionesResponse;
    }
}
