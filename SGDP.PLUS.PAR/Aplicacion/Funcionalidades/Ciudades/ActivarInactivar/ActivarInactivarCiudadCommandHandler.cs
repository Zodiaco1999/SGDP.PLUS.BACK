using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ActivarInactivar;

public class ActivarInactivarCiudadCommandHandler : IRequestHandler<ActivarInactivarCiudadCommand, ActivarInactivarCiudadResponse>
{
    private readonly IGestionCiudades _gestionCiudades;
    public ActivarInactivarCiudadCommandHandler(IGestionCiudades gestionCiudades) => _gestionCiudades = gestionCiudades;

    public async Task<ActivarInactivarCiudadResponse> Handle(ActivarInactivarCiudadCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarCiudadResponse result = await _gestionCiudades.ActivarInactivarCiudad(request.CiudadID);

        return result;
    }
}