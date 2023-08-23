using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ConsultarPorId;

public class ConsultarPaisPorIdQueryHandler : IRequestHandler<ConsultarPaisPorIdQuery, ConsultarPaisPorIdResponse>
{
    private readonly IGestionPaises _gestionPaises;
    public ConsultarPaisPorIdQueryHandler(IGestionPaises gestionPaises) => _gestionPaises = gestionPaises;

    public async Task<ConsultarPaisPorIdResponse> Handle(ConsultarPaisPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarPaisPorIdResponse result = await _gestionPaises.ConsultarPaisPorId(request.PaisId);

        return result;
    }
}