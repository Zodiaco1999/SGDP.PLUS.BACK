using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Editar;

public class EditarPerfilCommandHandler : IRequestHandler<EditarPerfilCommand, EditarPerfilResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;
    public EditarPerfilCommandHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;

    public async Task<EditarPerfilResponse> Handle(EditarPerfilCommand request, CancellationToken cancellationToken)
    {
        EditarPerfilResponse result = await _gestionPerfiles.EditarPerfil(request!);

        return result;
    }
}
