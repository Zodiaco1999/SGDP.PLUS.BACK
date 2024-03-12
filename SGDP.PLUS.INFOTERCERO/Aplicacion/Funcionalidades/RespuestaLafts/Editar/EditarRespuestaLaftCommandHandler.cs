using MediatR;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Editar;

public class EditarRespuestaLaftCommandHandler : IRequestHandler<EditarRespuestaLaftCommand, EditarRespuestaLaftResponse>
{
    private readonly IGestionRespuestaLafts _gestionRespuestaLafts;
    public EditarRespuestaLaftCommandHandler(IGestionRespuestaLafts gestionRespuestaLafts) => _gestionRespuestaLafts = gestionRespuestaLafts;

    public async Task<EditarRespuestaLaftResponse> Handle(EditarRespuestaLaftCommand request, CancellationToken cancellationToken)
    {
        EditarRespuestaLaftResponse result = await _gestionRespuestaLafts.EditarRespuestaLaft(request);

        return result;
    }
}