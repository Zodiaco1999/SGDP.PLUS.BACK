using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Usuarios.Editar;

public class EditarUsuariosCommandHandler : IRequestHandler<EditarUsuarioCommand, EditarUsuarioResponse>
{
    private readonly IGestionUsuarios _gestionUsuarios;
    public EditarUsuariosCommandHandler(IGestionUsuarios gestionUsuarios) => _gestionUsuarios = gestionUsuarios;

    public async Task<EditarUsuarioResponse> Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
    {
        EditarUsuarioResponse result = await _gestionUsuarios.EditarUsuario(request);

        return result;
    }
}