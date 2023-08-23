using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Lista;
public class ListaTipoDocumentoQueryHandler : IRequestHandler<ListaTipoDocumentoQuery, IEnumerable<ListaTipoDocumentoResponse>>
{
    private readonly IGestionTipoDocumentos _gestionTipoDocumentos;
    public ListaTipoDocumentoQueryHandler(IGestionTipoDocumentos gestionTipoDocumento) => _gestionTipoDocumentos = gestionTipoDocumento;

    public async Task<IEnumerable<ListaTipoDocumentoResponse>> Handle(ListaTipoDocumentoQuery request, CancellationToken cancellationToken) 
        => await _gestionTipoDocumentos.ListaTipoDocumento();

   
}
