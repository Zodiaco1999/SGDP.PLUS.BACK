using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.ActivarInactivar;

public class ActivarInactivarTipoDocumentoCommandHandler : IRequestHandler<ActivarInactivarTipoDocumentoCommand, ActivarInactivarTipoDocumentoResponse>
{
    private readonly IGestionTipoDocumentos _gestionTipoDocumentos;
    public ActivarInactivarTipoDocumentoCommandHandler(IGestionTipoDocumentos gestionTipoDocumentos) => _gestionTipoDocumentos = gestionTipoDocumentos;

    public async Task<ActivarInactivarTipoDocumentoResponse> Handle(ActivarInactivarTipoDocumentoCommand request, CancellationToken cancellationToken)
    {
        ActivarInactivarTipoDocumentoResponse result = await _gestionTipoDocumentos.ActivarInactivarTipoDocumento(request.TipoDocumentoId);

        return result;
    }
}