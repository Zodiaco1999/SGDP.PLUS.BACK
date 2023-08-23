using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.ConsultarPorId;

public class ConsultarCiudadPorIdQueryHandler : IRequestHandler<ConsultarCiudadPorIdQuery, ConsultarCiudadPorIdResponse>
{
    private readonly IGestionCiudades _gestionCiudades;
    public ConsultarCiudadPorIdQueryHandler(IGestionCiudades gestionCiudades) => _gestionCiudades = gestionCiudades;

    public async Task<ConsultarCiudadPorIdResponse> Handle(ConsultarCiudadPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarCiudadPorIdResponse result = await _gestionCiudades.ConsultarCiudadPorId(request.CiudadId);

        return result;
    }
}