using MediatR;
using SEG.MENU.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

namespace SEG.MENU.Aplicacion.Funcionalidades.Modulos.ActivarInactivar;

public class ActivarInactivarModuloCommandHandler : IRequestHandler<ActivarInactivarModuloCommand>
{
    private readonly IGestionModulos _gestionModulos;
    public ActivarInactivarModuloCommandHandler(IGestionModulos gestionModulos) => _gestionModulos = gestionModulos;

    public async Task Handle(ActivarInactivarModuloCommand request, CancellationToken cancellationToken) =>
        await _gestionModulos.ActivarInactivarModulo(request.ModuloId);
}