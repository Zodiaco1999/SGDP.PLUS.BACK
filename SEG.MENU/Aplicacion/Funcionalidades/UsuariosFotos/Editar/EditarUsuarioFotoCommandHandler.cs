using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.UsuariosFotos.Editar;

public class EditarUsuarioFotoCommandHandler : IRequestHandler<EditarUsuarioFotoCommand, EditarUsuarioFotoResponse>
{
    private readonly IGestionUsuariosFotos _gestionUsuariosFotos;
    public EditarUsuarioFotoCommandHandler(IGestionUsuariosFotos gestionUsuariosFotos) => _gestionUsuariosFotos = gestionUsuariosFotos;

    public async Task<EditarUsuarioFotoResponse> Handle(EditarUsuarioFotoCommand request, CancellationToken cancellationToken)
    {
        EditarUsuarioFotoResponse result = await _gestionUsuariosFotos.EditarUsuarioFoto(request);

        return result;
    }
}