using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.ActivarInactivar;

public class ActivarInactivarPerfilCommandHandler : IRequestHandler<ActivarInactivarPerfilCommand, ActivarInactivarPerfilResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;
    public ActivarInactivarPerfilCommandHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;

    public async Task<ActivarInactivarPerfilResponse> Handle(ActivarInactivarPerfilCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarPerfilResponse result = await _gestionPerfiles.ActivarInactivarPerfil(request.PerfilId);

        return result;
    }
}
