using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Menus.ConusltarPorParametros;

public class ConsultarMenusPorParametrosQueryHandler : IRequestHandler<ConsultarMenusPorParametrosQuery, IEnumerable<ConsultarMenusPorParametrosResponse>>
{
    private readonly IGestionMenus _gestionMenus;
    public ConsultarMenusPorParametrosQueryHandler(IGestionMenus gestionMenus) => _gestionMenus = gestionMenus;

    public async Task<IEnumerable<ConsultarMenusPorParametrosResponse>> Handle(ConsultarMenusPorParametrosQuery request, CancellationToken cancellationToken)
        => await _gestionMenus.ConsultarMenusPorParametros(request.AplicacionId, request.ModuloId, request.TextoBusqueda);
    
}
