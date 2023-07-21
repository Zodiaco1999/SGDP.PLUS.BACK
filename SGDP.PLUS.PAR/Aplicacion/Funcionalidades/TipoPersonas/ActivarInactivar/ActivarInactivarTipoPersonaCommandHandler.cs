using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.ActivarInactivar;

public class ActivarInactivarTipoPersonaCommandHandler : IRequestHandler<ActivarInactivarTipoPersonaCommand, ActivarInactivarTipoPersonaResponse>
{
    private readonly IGestionTipoPersonas _gestionTipoPersonas;
    public ActivarInactivarTipoPersonaCommandHandler(IGestionTipoPersonas gestionTipoPersonas) => _gestionTipoPersonas = gestionTipoPersonas;

    public async Task<ActivarInactivarTipoPersonaResponse> Handle(ActivarInactivarTipoPersonaCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarTipoPersonaResponse result = await _gestionTipoPersonas.ActivarInactivarTipoPersona(request.TipoPersonaId);

        return result;
    }
}