using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SEG.MENU.Dominio.Entidades;

namespace SEG.MENU.Aplicacion.Funcionalidades.PerfilMenus.Crear;

public class CrearPerfilMenusCommandHandler : IRequestHandler<CrearPerfilMenusCommand, CrearPerfilMenusResponse>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public CrearPerfilMenusCommandHandler(IGestionPerfilMenus gestionPerfilMenus) => _gestionPerfilMenus = gestionPerfilMenus;
    
    public async Task<CrearPerfilMenusResponse> Handle(CrearPerfilMenusCommand request, CancellationToken cancellationToken)
    {
        return await _gestionPerfilMenus.CrearPerfilMenu(request);
    }
}
