using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Apis.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Apis.ActivarInactivar;

public class ActivarInactivarApiCommandHandler : IRequestHandler<ActivarInactivarApiCommand>
{
    private readonly IGestionApis _gestionApis;
    public ActivarInactivarApiCommandHandler(IGestionApis gestionApis) => _gestionApis = gestionApis;

    public async Task Handle(ActivarInactivarApiCommand request, CancellationToken cancellationToken) =>
        await _gestionApis.ActivarInactivarApi(request.ApiId);
    
}