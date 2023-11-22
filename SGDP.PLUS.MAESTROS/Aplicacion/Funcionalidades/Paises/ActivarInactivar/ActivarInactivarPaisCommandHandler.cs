using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.ActivarInactivar;

public class ActivarInactivarPaisCommandHandler : IRequestHandler<ActivarInactivarPaisCommand, ActivarInactivarPaisResponse>
{
    private readonly IGestionPaises _gestionPaises;
    public ActivarInactivarPaisCommandHandler(IGestionPaises gestionPaises) => _gestionPaises = gestionPaises;

    public async Task<ActivarInactivarPaisResponse> Handle(ActivarInactivarPaisCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarPaisResponse result = await _gestionPaises.ActivarInactivarPais(request.PaisId);

        return result;
    }
}