using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.ConsultarPorId;

public class ConsultarCargoPorIdQueryHandler : IRequestHandler<ConsultarCargoPorIdQuery, ConsultarCargoPorIdResponse>
{
    private readonly IGestionCargos _gestionCargos;
    public ConsultarCargoPorIdQueryHandler(IGestionCargos gestionCargos) => _gestionCargos = gestionCargos;

    public async Task<ConsultarCargoPorIdResponse> Handle(ConsultarCargoPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarCargoPorIdResponse result = await _gestionCargos.ConsultarCargoPorId(request.CargoId);

        return result;
    }
}