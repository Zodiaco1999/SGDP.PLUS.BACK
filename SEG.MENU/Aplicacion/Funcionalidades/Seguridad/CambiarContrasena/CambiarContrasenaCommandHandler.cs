using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.CambiarContraseña;

public class CambiarContrasenaCommandHandler : IRequestHandler<CambiarContrasenaCommand, CambiarContrasenaResponse> 
{
    private readonly IGestionSeguridad _gestionSeguridad;

    public CambiarContrasenaCommandHandler(IGestionSeguridad gestionSeguridad) => _gestionSeguridad= gestionSeguridad;

    public async Task<CambiarContrasenaResponse> Handle(CambiarContrasenaCommand request, CancellationToken cancellationToken)
        => await _gestionSeguridad.CambiarContraseña(request);

    
}



