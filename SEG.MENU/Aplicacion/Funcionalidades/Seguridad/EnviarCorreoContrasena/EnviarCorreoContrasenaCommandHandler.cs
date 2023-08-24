using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.EnviarCorreoContrasena;

public class EnviarCorreoContrasenaCommandHandler :IRequestHandler<EnviarCorreoContrasenaCommand, EnviarCorreoContrasenaResponse> 
{
    private readonly IGestionSeguridad _gestionSeguridad;

    public EnviarCorreoContrasenaCommandHandler(IGestionSeguridad gestionSeguridad) => _gestionSeguridad = gestionSeguridad;

    public async Task<EnviarCorreoContrasenaResponse> Handle(EnviarCorreoContrasenaCommand request, CancellationToken cancellationToken)
        => await _gestionSeguridad.EnviarCorreoContrasena(request);
}


