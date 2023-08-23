using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Crear;

public class CrearTipoDocumentoCommandHandler : IRequestHandler<CrearTipoDocumentoCommand, CrearTipoDocumentoResponse>
{
    private readonly IGestionTipoDocumentos _gestionTipoDocumentos;
    public CrearTipoDocumentoCommandHandler(IGestionTipoDocumentos gestionTipoDocumentos) => _gestionTipoDocumentos = gestionTipoDocumentos;

    public async Task<CrearTipoDocumentoResponse> Handle(CrearTipoDocumentoCommand request, CancellationToken cancellationToken)
    {
        CrearTipoDocumentoResponse result = await _gestionTipoDocumentos.CrearTipoDocumento(request);

        return result;
    }
}