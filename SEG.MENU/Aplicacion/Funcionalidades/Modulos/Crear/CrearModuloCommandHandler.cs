using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.Crear;

public class CrearModuloCommandHandler : IRequestHandler<CrearModuloCommand, CrearModuloResponse>
{
    private readonly IGestionModulos _gestionModulos;
    public CrearModuloCommandHandler(IGestionModulos gestionModulos) => _gestionModulos = gestionModulos;

    public async Task<CrearModuloResponse> Handle(CrearModuloCommand request, CancellationToken cancellationToken) =>
        await _gestionModulos.CrearModulo(request);
    
}