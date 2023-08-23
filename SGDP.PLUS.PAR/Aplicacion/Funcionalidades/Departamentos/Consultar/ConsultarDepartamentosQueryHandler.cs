using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Consultar;

public class ConsultarDepartamentosQueryHandler : IRequestHandler<ConsultarDepartamentosQuery, DataViewModel<ConsultarDepartamentosResponse>>
{
    private readonly IGestionDepartamentos _gestionDepartamentos;
    public ConsultarDepartamentosQueryHandler(IGestionDepartamentos gestionDepartamentos) => _gestionDepartamentos = gestionDepartamentos;

    public async Task<DataViewModel<ConsultarDepartamentosResponse>> Handle(ConsultarDepartamentosQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarDepartamentosResponse> result = await _gestionDepartamentos.ConsultarDepartamentos(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}