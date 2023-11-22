using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Consultar;

public class ConsultarTipoPersonasQueryHandler : IRequestHandler<ConsultarTipoPersonasQuery, DataViewModel<ConsultarTipoPersonasResponse>>
{
    private readonly IGestionTipoPersonas _gestionTipoPersonas;
    public ConsultarTipoPersonasQueryHandler(IGestionTipoPersonas gestionTipoPersonas) => _gestionTipoPersonas = gestionTipoPersonas;

    public async Task<DataViewModel<ConsultarTipoPersonasResponse>> Handle(ConsultarTipoPersonasQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarTipoPersonasResponse> result = await _gestionTipoPersonas.ConsultarTipoPersonas(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}