using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Ciudades.Consultar;

public class ConsultarCiudadesQueryHandler : IRequestHandler<ConsultarCiudadesQuery, DataViewModel<ConsultarCiudadesResponse>>
{
    private readonly IGestionCiudades _gestionCiudades;
    public ConsultarCiudadesQueryHandler(IGestionCiudades gestionCiudades) => _gestionCiudades = gestionCiudades;

    public async Task<DataViewModel<ConsultarCiudadesResponse>> Handle(ConsultarCiudadesQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarCiudadesResponse> result = await _gestionCiudades.ConsultarCiudades(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}