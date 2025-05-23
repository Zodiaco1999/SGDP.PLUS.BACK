using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Apis.Editar;

public class EditarApiCommandHandler : IRequestHandler<EditarApiCommand>
{
    private readonly IGestionApis _gestionApis;
    public EditarApiCommandHandler(IGestionApis gestionApis) => _gestionApis = gestionApis;

    public async Task Handle(EditarApiCommand request, CancellationToken cancellationToken) =>
        await _gestionApis.EditarApi(request);

}