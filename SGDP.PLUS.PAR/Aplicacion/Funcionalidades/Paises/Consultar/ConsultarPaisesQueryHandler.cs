using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;

public class ConsultarPaisesQueryHandler : IRequestHandler<ConsultarPaisesQuery, DataViewModel<ConsultarPaisesResponse>>
{
    private readonly IGestionPaises _gestionPaises;
    public ConsultarPaisesQueryHandler(IGestionPaises gestionPaises) => _gestionPaises = gestionPaises;

    public async Task<DataViewModel<ConsultarPaisesResponse>> Handle(ConsultarPaisesQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarPaisesResponse> result = await _gestionPaises.ConsultarPaises(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}