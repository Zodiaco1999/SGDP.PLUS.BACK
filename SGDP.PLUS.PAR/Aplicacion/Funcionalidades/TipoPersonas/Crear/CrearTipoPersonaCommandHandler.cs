using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoPersonas.Crear;

public class CrearTipoPersonaCommandHandler : IRequestHandler<CrearTipoPersonaCommand, CrearTipoPersonaResponse>
{
    private readonly IGestionTipoPersonas _gestionTipoPersonas;
    public CrearTipoPersonaCommandHandler(IGestionTipoPersonas gestionTipoPersonas) => _gestionTipoPersonas = gestionTipoPersonas;

    public async Task<CrearTipoPersonaResponse> Handle(CrearTipoPersonaCommand request, CancellationToken cancellationToken)
    {
        CrearTipoPersonaResponse result = await _gestionTipoPersonas.CrearTipoPersona(request);

        return result;
    }
}