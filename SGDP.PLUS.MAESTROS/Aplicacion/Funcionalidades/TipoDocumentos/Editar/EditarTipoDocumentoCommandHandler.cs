using MediatR;
using SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.LogicaNegocio;

namespace SGDP.PLUS.MAESTROS.Aplicacion.Funcionalidades.TipoDocumentos.Editar;

public class EditarTipoDocumentoCommandHandler : IRequestHandler<EditarTipoDocumentoCommand, EditarTipoDocumentoResponse>
{
    private readonly IGestionTipoDocumentos _gestionTipoDocumentos;
    public EditarTipoDocumentoCommandHandler(IGestionTipoDocumentos gestionTipoDocumentos) => _gestionTipoDocumentos = gestionTipoDocumentos;

    public async Task<EditarTipoDocumentoResponse> Handle(EditarTipoDocumentoCommand request, CancellationToken cancellationToken)
    {
        EditarTipoDocumentoResponse result = await _gestionTipoDocumentos.EditarTipoDocumento(request);

        return result;
    }
}