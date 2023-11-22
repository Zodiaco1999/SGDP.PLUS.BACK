using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Refresh;

public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshResponse>
{
    private readonly IGestionAutenticacion _gestionAutenticacion;
    public RefreshCommandHandler(IGestionAutenticacion gestionAutenticacion) => _gestionAutenticacion = gestionAutenticacion;

    public async Task<RefreshResponse> Handle(RefreshCommand request, CancellationToken cancellationToken)
        => await _gestionAutenticacion.Refresh(request);
}
