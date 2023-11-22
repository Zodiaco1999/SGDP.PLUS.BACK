using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Autenticacion.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IGestionAutenticacion _gestionAutenticacion;
    public LoginCommandHandler(IGestionAutenticacion gestionAutenticacion) => _gestionAutenticacion = gestionAutenticacion;
    
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        => await _gestionAutenticacion.Login(request);
}

