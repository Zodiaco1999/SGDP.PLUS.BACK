using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContrasena;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.CambiarContraseña;

public class CambiarContrasenaCommandHandler : IRequestHandler<CambiarContrasenaCommand, CambiarContrasenaResponse> 
{
    private readonly IGestionAutenticacion _gestionAutenticacion;

    public CambiarContrasenaCommandHandler(IGestionAutenticacion gestionAutenticacion) => _gestionAutenticacion= gestionAutenticacion;

    public async Task<CambiarContrasenaResponse> Handle(CambiarContrasenaCommand request, CancellationToken cancellationToken)
        => await _gestionAutenticacion.CambiarContraseña(request);

    
}



