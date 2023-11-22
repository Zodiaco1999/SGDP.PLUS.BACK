using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Crear;

public class CrearPaisCommandHandler : IRequestHandler<CrearPaisCommand, CrearPaisResponse>
{
    private readonly IGestionPaises _gestionPaises;
    public CrearPaisCommandHandler(IGestionPaises gestionPaises) => _gestionPaises = gestionPaises;

    public async Task<CrearPaisResponse> Handle(CrearPaisCommand request, CancellationToken cancellationToken)
    {
        CrearPaisResponse result = await _gestionPaises.CrearPais(request);

        return result;
    }
}