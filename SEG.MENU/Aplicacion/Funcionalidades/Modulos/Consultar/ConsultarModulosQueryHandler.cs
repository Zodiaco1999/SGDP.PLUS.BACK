using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Modulos.Consultar;

public class ConsultarModulosQueryHandler : IRequestHandler<ConsultarModulosQuery, IEnumerable<ConsultarModulosResponse>>
{
    private readonly IGestionModulos _gestionModulos;
    public ConsultarModulosQueryHandler(IGestionModulos gestionModulos) => _gestionModulos = gestionModulos;

    public async Task<IEnumerable<ConsultarModulosResponse>> Handle(ConsultarModulosQuery request, CancellationToken cancellationToken)
        => await _gestionModulos.ConsultarModulos(request.AplicacionId);
}