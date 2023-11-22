using MediatR;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;
using SGDP.PLUS.SEG.Dominio.Entidades;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Crear;

public class CrearAplicacionCommandHandler : IRequestHandler<CrearAplicacionCommand, CrearAplicacionResponse>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public CrearAplicacionCommandHandler(IGestionAplicaciones gestionAplicaciones) => _gestionAplicaciones = gestionAplicaciones;

    public async Task<CrearAplicacionResponse> Handle(CrearAplicacionCommand request, CancellationToken cancellationToken)
    {
        var result = await _gestionAplicaciones.CrearAplicacion(request);

        return result;
    }
}
