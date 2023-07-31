using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.ConsultarPorId;

public class ConsultarDepartamentoPorIdQueryHandler : IRequestHandler<ConsultarDepartamentoPorIdQuery, ConsultarDepartamentoPorIdResponse>
{
    private readonly IGestionDepartamentos _gestionDepartamentos;
    public ConsultarDepartamentoPorIdQueryHandler(IGestionDepartamentos gestionDepartamentos) => _gestionDepartamentos = gestionDepartamentos;

    public async Task<ConsultarDepartamentoPorIdResponse> Handle(ConsultarDepartamentoPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarDepartamentoPorIdResponse result = await _gestionDepartamentos.ConsultarDepartamentoPorId(request.DepartamentoId);

        return result;
    }
}