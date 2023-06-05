using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;

public class CrearPerfilesCommandHandler : IRequestHandler<CrearPerfilesCommand, CrearPerfilesResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;

    public CrearPerfilesCommandHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;
    
    public async Task<CrearPerfilesResponse> Handle(CrearPerfilesCommand request, CancellationToken cancellationToken)
    {
        return await _gestionPerfiles.CrearPerfil(request);
    }
}
