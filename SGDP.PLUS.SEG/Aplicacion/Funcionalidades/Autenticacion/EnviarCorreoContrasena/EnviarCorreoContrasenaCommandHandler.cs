using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.EnviarCorreoContrasena;

public class EnviarCorreoContrasenaCommandHandler :IRequestHandler<EnviarCorreoContrasenaCommand, EnviarCorreoContrasenaResponse> 
{
    private readonly IGestionAutenticacion _gestionAutenticacion;

    public EnviarCorreoContrasenaCommandHandler(IGestionAutenticacion gestionAutenticacion) => _gestionAutenticacion = gestionAutenticacion;

    public async Task<EnviarCorreoContrasenaResponse> Handle(EnviarCorreoContrasenaCommand request, CancellationToken cancellationToken)
        => await _gestionAutenticacion.EnviarCorreoContrasena(request);
}


