using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Paises.Lista;

public class ListaPaisesQueryHandler : IRequestHandler<ListaPaisesQuery, IEnumerable<ListaPaisesResponse>>
{
    private readonly IGestionPaises _gestionPaises;
    public ListaPaisesQueryHandler(IGestionPaises gestionPaises) => _gestionPaises = gestionPaises;

    public async Task<IEnumerable<ListaPaisesResponse>> Handle(ListaPaisesQuery request, CancellationToken cancellationToken)
        => await _gestionPaises.ListaPaises();
}