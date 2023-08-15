using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Aplicaciones.Lista;

public class ListaAplicacionesQueryHandler : IRequestHandler<ListaAplicacionesQuery, IEnumerable<ListaAplicacionesResponse>>
{
    private readonly IGestionAplicaciones _gestionAplicaciones;

    public ListaAplicacionesQueryHandler(IGestionAplicaciones gestionAplicaciones)
    {
        _gestionAplicaciones = gestionAplicaciones;
    }

    public async Task<IEnumerable<ListaAplicacionesResponse>> Handle(ListaAplicacionesQuery request, CancellationToken cancellationToken)
        => await _gestionAplicaciones.ListaAplicaciones();
}
