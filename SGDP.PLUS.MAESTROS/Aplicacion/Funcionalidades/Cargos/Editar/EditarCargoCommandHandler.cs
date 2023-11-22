using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Cargos.Editar;

public class EditarCargoCommandHandler : IRequestHandler<EditarCargoCommand, EditarCargoResponse>
{
    private readonly IGestionCargos _gestionCargos;
    public EditarCargoCommandHandler(IGestionCargos gestionCargos) => _gestionCargos = gestionCargos;

    public async Task<EditarCargoResponse> Handle(EditarCargoCommand request, CancellationToken cancellationToken)
    {
        EditarCargoResponse result = await _gestionCargos.EditarCargo(request);

        return result;
    }
}