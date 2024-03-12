using MediatR;
using SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.LogicaNegocio;

namespace SGDP.PLUS.INFOTERCERO.Aplicacion.Funcionalidades.RespuestaLafts.Crear;

public class CrearRespuestaLaftCommandHandler : IRequestHandler<CrearRespuestaLaftCommand, CrearRespuestaLaftResponse>
{
    private readonly IGestionRespuestaLafts _gestionRespuestaLafts;
    public CrearRespuestaLaftCommandHandler(IGestionRespuestaLafts gestionRespuestaLafts) => _gestionRespuestaLafts = gestionRespuestaLafts;

    public async Task<CrearRespuestaLaftResponse> Handle(CrearRespuestaLaftCommand request, CancellationToken cancellationToken)
    {
        CrearRespuestaLaftResponse result = await _gestionRespuestaLafts.CrearRespuestaLaft(request);

        return result;
    }
}