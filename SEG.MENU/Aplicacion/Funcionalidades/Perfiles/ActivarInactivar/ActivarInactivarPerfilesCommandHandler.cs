using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

public class ActivarInactivarPerfilesCommandHandler : IRequestHandler<ActivarInactivarPerfilesCommand, ActivarInactivarPerfilesResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;
    public ActivarInactivarPerfilesCommandHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;

    public async Task<ActivarInactivarPerfilesResponse> Handle(ActivarInactivarPerfilesCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarPerfilesResponse result = await _gestionPerfiles.ActivarInactivar(request.PerfilId);

        return result;
    }
}
