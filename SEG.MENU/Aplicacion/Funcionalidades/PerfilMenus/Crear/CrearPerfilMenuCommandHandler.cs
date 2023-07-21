using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.LogicaNegocio;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.PerfilMenus.Crear;

public class CrearPerfilMenuCommandHandler : IRequestHandler<CrearPerfilMenuCommand, CrearPerfilMenuResponse>
{
    private readonly IGestionPerfilMenus _gestionPerfilMenus;

    public CrearPerfilMenuCommandHandler(IGestionPerfilMenus gestionPerfilMenus) => _gestionPerfilMenus = gestionPerfilMenus;
    
    public async Task<CrearPerfilMenuResponse> Handle(CrearPerfilMenuCommand request, CancellationToken cancellationToken)
    {
        return await _gestionPerfilMenus.CrearPerfilMenu(request);
    }
}
