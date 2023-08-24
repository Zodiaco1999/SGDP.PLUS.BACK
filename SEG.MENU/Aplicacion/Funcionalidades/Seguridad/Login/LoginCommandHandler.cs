using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Seguridad.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IGestionSeguridad _gestionSeguridad;
    public LoginCommandHandler(IGestionSeguridad gestionSeguridad) => _gestionSeguridad = gestionSeguridad;
    
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        => await _gestionSeguridad.Login(request);
}

