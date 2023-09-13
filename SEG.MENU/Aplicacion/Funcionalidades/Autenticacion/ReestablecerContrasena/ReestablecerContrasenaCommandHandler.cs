using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.ReestablecerContrasena;

public class ReestablecerContrasenaCommandHandler : IRequestHandler<ReestablecerContrasenaCommand, ReestablecerContrasenaResponse>
{
    private readonly IGestionAutenticacion _gestionAutenticacion;

    public ReestablecerContrasenaCommandHandler(IGestionAutenticacion gestionAutenticacion) => _gestionAutenticacion = gestionAutenticacion;

    public async Task<ReestablecerContrasenaResponse> Handle(ReestablecerContrasenaCommand request, CancellationToken cancellationToken)
        => await _gestionAutenticacion.ReestablecerContrasena(request);
}

