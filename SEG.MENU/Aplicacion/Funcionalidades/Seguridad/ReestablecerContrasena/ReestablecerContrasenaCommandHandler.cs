using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.ReestablecerContrasena;

public class ReestablecerContrasenaCommandHandler : IRequestHandler<ReestablecerContrasenaCommand, ReestablecerContrasenaResponse>
{
    private readonly IGestionSeguridad _gestionSeguridad;

    public ReestablecerContrasenaCommandHandler(IGestionSeguridad gestionSeguridad) => _gestionSeguridad = gestionSeguridad;

    public async Task<ReestablecerContrasenaResponse> Handle(ReestablecerContrasenaCommand request, CancellationToken cancellationToken)
        => await _gestionSeguridad.ReestablecerContrasena(request);
}

