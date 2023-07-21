using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Editar;

public class EditarModuloCommandHandler : IRequestHandler<EditarModuloCommand>
{
    private readonly IGestionModulos _gestionModulos;
    public EditarModuloCommandHandler(IGestionModulos gestionModulos) => _gestionModulos = gestionModulos;

    public async Task Handle(EditarModuloCommand request, CancellationToken cancellationToken) =>
        await _gestionModulos.EditarModulo(request);
    
}