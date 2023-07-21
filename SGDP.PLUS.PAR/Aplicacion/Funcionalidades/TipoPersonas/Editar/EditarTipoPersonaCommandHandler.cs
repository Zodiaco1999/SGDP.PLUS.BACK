using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Editar;

public class EditarTipoPersonaCommandHandler : IRequestHandler<EditarTipoPersonaCommand, EditarTipoPersonaResponse>
{
    private readonly IGestionTipoPersonas _gestionTipoPersonas;
    public EditarTipoPersonaCommandHandler(IGestionTipoPersonas gestionTipoPersonas) => _gestionTipoPersonas = gestionTipoPersonas;

    public async Task<EditarTipoPersonaResponse> Handle(EditarTipoPersonaCommand request, CancellationToken cancellationToken)
    {
        EditarTipoPersonaResponse result = await _gestionTipoPersonas.EditarTipoPersona(request!);

        return result;
    }
}