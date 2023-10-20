using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.RestablecerContrasena;

public class RestablecerContrasenaCommandHandler : IRequestHandler<RestablecerContrasenaCommand, RestablecerContrasenaResponse>
{
    private readonly IGestionAutenticacion _gestionAutenticacion;

    public RestablecerContrasenaCommandHandler(IGestionAutenticacion gestionAutenticacion) => _gestionAutenticacion = gestionAutenticacion;

    public async Task<RestablecerContrasenaResponse> Handle(RestablecerContrasenaCommand request, CancellationToken cancellationToken)
        => await _gestionAutenticacion.RestablecerContrasena(request);
}

