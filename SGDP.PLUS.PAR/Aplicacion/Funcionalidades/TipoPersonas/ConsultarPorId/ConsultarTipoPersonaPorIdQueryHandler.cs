using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ConsultarPorId;

public class ConsultarTipoPersonaPorIdQueryHandler : IRequestHandler<ConsultarTipoPersonaPorIdQuery, ConsultarTipoPersonaPorIdResponse>
{
    private readonly IGestionTipoPersonas _gestionTipoPersonas;
    public ConsultarTipoPersonaPorIdQueryHandler(IGestionTipoPersonas gestionTipoPersonas) => _gestionTipoPersonas = gestionTipoPersonas;

    public async Task<ConsultarTipoPersonaPorIdResponse> Handle(ConsultarTipoPersonaPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarTipoPersonaPorIdResponse result = await _gestionTipoPersonas.ConsultarTipoPersonaPorId(request.TipoPersonaId);

        return result;
    }
}