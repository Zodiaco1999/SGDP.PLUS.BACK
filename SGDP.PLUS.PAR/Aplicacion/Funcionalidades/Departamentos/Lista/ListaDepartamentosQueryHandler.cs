using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.Departamentos.Lista;

public class ListaDepartamentosQueryHandler : IRequestHandler<ListaDepartamentosQuery, IEnumerable<ListaDepartamentosResponse>>
{
    private readonly IGestionDepartamentos _gestionDepartamentos;
    public ListaDepartamentosQueryHandler(IGestionDepartamentos gestionPaises) => _gestionDepartamentos = gestionPaises;

    public async Task<IEnumerable<ListaDepartamentosResponse>> Handle(ListaDepartamentosQuery request, CancellationToken cancellationToken)
        => await _gestionDepartamentos.ListaDepartamentos();
}