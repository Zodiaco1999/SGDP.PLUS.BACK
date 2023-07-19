using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;
using SEG.MENU.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.Perfiles.Crear;

public class CrearPerfilCommandHandler : IRequestHandler<CrearPerfilCommand, CrearPerfilResponse>
{
    private readonly IGestionPerfiles _gestionPerfiles;

    public CrearPerfilCommandHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;
    
    public async Task<CrearPerfilResponse> Handle(CrearPerfilCommand request, CancellationToken cancellationToken)
    {
        return await _gestionPerfiles.CrearPerfil(request);
    }
}
