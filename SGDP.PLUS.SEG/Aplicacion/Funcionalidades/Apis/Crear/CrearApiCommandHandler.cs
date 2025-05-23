using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Crear;

public class CrearApiCommandHandler : IRequestHandler<CrearApiCommand, CrearApiResponse>
{
    private readonly IGestionApis _gestionApis;
    public CrearApiCommandHandler(IGestionApis gestionApis) => _gestionApis = gestionApis;

    public async Task<CrearApiResponse> Handle(CrearApiCommand request, CancellationToken cancellationToken) =>
        await _gestionApis.CrearApi(request);

}