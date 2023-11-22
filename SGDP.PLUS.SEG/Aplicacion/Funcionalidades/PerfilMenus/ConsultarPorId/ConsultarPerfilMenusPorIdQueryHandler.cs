using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPorId;

public class ConsultarPerfilMenusPorIdQueryHandler : IRequestHandler<ConsultarPerfilMenusPorIdQuery, IEnumerable<ConsultarPerfilMenusPorIdResponse>>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public ConsultarPerfilMenusPorIdQueryHandler(IGestionPerfilMenus gestionPerfilMenus)
    {
        _gestionPerfilMenus = gestionPerfilMenus;
    }

    public async Task<IEnumerable<ConsultarPerfilMenusPorIdResponse>> Handle(ConsultarPerfilMenusPorIdQuery request, CancellationToken cancellationToken)
        => await _gestionPerfilMenus.ConsultarPerfilMenuPorId(request.PerfilId);
}