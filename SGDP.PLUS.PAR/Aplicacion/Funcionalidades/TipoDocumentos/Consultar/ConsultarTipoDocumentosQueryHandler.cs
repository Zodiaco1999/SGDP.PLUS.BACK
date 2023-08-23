using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Consultar;

public class ConsultarTipoDocumentosQueryHandler : IRequestHandler<ConsultarTipoDocumentosQuery, DataViewModel<ConsultarTipoDocumentosResponse>>
{
    private readonly IGestionTipoDocumentos _gestionTipoDocumentos;
    public ConsultarTipoDocumentosQueryHandler(IGestionTipoDocumentos gestionTipoDocumentos) => _gestionTipoDocumentos = gestionTipoDocumentos;

    public async Task<DataViewModel<ConsultarTipoDocumentosResponse>> Handle(ConsultarTipoDocumentosQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarTipoDocumentosResponse> result = await _gestionTipoDocumentos.ConsultarTipoDocumentos(request.textoBusqueda, request.pagina, request.registrosPorPagina);

        return result;
    }
}