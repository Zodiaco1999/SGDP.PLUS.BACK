using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Consultar;

public class ConsultarCargosQueryHandler : IRequestHandler<ConsultarCargosQuery, DataViewModel<ConsultarCargosResponse>>
{
    private readonly IGestionCargos _gestionCargos;
    public ConsultarCargosQueryHandler(IGestionCargos gestionCargos) => _gestionCargos = gestionCargos;

    public async Task<DataViewModel<ConsultarCargosResponse>> Handle(ConsultarCargosQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarCargosResponse> result = await _gestionCargos.ConsultarCargos(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}