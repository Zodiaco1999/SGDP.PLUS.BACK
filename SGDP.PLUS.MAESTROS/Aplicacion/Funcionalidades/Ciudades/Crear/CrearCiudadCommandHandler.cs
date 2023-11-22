using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Crear;

public class CrearCiudadCommandHandler : IRequestHandler<CrearCiudadCommand, CrearCiudadResponse>
{
    private readonly IGestionCiudades _gestionCiudades;
    public CrearCiudadCommandHandler(IGestionCiudades gestionCiudades) => _gestionCiudades = gestionCiudades;

    public async Task<CrearCiudadResponse> Handle(CrearCiudadCommand request, CancellationToken cancellationToken)
    {
        CrearCiudadResponse result = await _gestionCiudades.CrearCiudad(request);

        return result;
    }
}