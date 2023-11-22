using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Editar;

public class EditarPaisCommandHandler : IRequestHandler<EditarPaisCommand, EditarPaisResponse>
{
    private readonly IGestionPaises _gestionPaises;
    public EditarPaisCommandHandler(IGestionPaises gestionPaises) => _gestionPaises = gestionPaises;

    public async Task<EditarPaisResponse> Handle(EditarPaisCommand request, CancellationToken cancellationToken)
    {
        EditarPaisResponse result = await _gestionPaises.EditarPais(request);

        return result;
    }
}