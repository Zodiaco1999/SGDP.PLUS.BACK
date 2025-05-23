using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Consultar;

public class ConsultaPaisesQueryHandler : IRequestHandler<ConsultaPaisesQuery, DataViewModel<ConsultaPaisesResponse>>
{
    private readonly IGestionPaises _gestionPaises;
    public ConsultaPaisesQueryHandler(IGestionPaises gestionPaises) => _gestionPaises = gestionPaises;

    public async Task<DataViewModel<ConsultaPaisesResponse>> Handle(ConsultaPaisesQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultaPaisesResponse> result = await _gestionPaises.ConsultarPaises(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}