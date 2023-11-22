using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ConsultarPorId;

public class ConsultarTipoDocumentoPorIdQueryHandler : IRequestHandler<ConsultarTipoDocumentoPorIdQuery, ConsultarTipoDocumentoPorIdResponse>
{
    private readonly IGestionTipoDocumentos _gestionTipoDocumentos;
    public ConsultarTipoDocumentoPorIdQueryHandler(IGestionTipoDocumentos gestionTipoDocumentos) => _gestionTipoDocumentos = gestionTipoDocumentos;

    public async Task<ConsultarTipoDocumentoPorIdResponse> Handle(ConsultarTipoDocumentoPorIdQuery request, CancellationToken cancellationToken)
    {
        ConsultarTipoDocumentoPorIdResponse result = await _gestionTipoDocumentos.ConsultarTipoDocumentoPorId(request.TipoDocumentoId);

        return result;
    }
}