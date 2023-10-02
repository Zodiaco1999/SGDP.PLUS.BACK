using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
{
    private readonly IGestionAutenticacion _gestionAutenticacion;
    public LogoutCommandHandler(IGestionAutenticacion gestionAutenticacion) => _gestionAutenticacion = gestionAutenticacion;

    public Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        => _gestionAutenticacion.Logout();
}
