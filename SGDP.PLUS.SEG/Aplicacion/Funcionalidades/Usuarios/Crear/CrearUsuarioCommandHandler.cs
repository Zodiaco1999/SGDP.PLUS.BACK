using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Crear;

public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, CrearUsuarioResponse>
{
    private readonly IGestionUsuarios _gestionUsuarios;
    public CrearUsuarioCommandHandler(IGestionUsuarios gestionUsuarios) => _gestionUsuarios = gestionUsuarios;

    public async Task<CrearUsuarioResponse> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
    {
        CrearUsuarioResponse result = await _gestionUsuarios.CrearUsuario(request);

        return result;
    }
}