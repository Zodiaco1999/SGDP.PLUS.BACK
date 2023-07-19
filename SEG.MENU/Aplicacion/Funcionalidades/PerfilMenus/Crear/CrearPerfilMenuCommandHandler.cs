using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Crear;

public class CrearPerfilMenuCommandHandler : IRequestHandler<CrearPerfilMenuCommand, CrearPerfilMenuResponse>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public CrearPerfilMenuCommandHandler(IGestionPerfilMenus gestionPerfilMenus) => _gestionPerfilMenus = gestionPerfilMenus;
    
    public async Task<CrearPerfilMenuResponse> Handle(CrearPerfilMenuCommand request, CancellationToken cancellationToken)
    {
        return await _gestionPerfilMenus.CrearPerfilMenu(request);
    }
}
