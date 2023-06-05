using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Editar;

public class EditarPerfilesCommandHandler : IRequestHandler<EditarPerfilesCommand, EditarPerfilesResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;
    public EditarPerfilesCommandHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;

    public async Task<EditarPerfilesResponse> Handle(EditarPerfilesCommand request, CancellationToken cancellationToken)
    {
        EditarPerfilesResponse result = await _gestionPerfiles.ActualizarPerfil(request!);

        return result;
    }
}
