using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.ConsultarPerfilesPorApp;
public class ConsultarPerfilesPorAplicacionQueryHandler : IRequestHandler<ConsultarPerfilesPorAplicacionQuery, IEnumerable<ConsultarPerfilesPorAplicacionResponse>>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;
    public ConsultarPerfilesPorAplicacionQueryHandler(IGestionPerfilMenus gestionPerfilMenus) => _gestionPerfilMenus = gestionPerfilMenus;

    public async Task<IEnumerable<ConsultarPerfilesPorAplicacionResponse>> Handle(ConsultarPerfilesPorAplicacionQuery request, CancellationToken cancellationToken)
        => await _gestionPerfilMenus.ConsultarPerfilesPorAplicacion(request.AplicacionId);

}

