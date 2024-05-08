using MediatR;
using SGDP.PLUS.Comun.General;
using SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.LogicaNegocio;

namespace SGDP.PLUS.SEG.Aplicacion.Funcionalidades.Perfiles.Consultar;

public class ConsultarPerfilesQueryHandler : IRequestHandler<ConsultarPerfilesQuery, DataViewModel<ConsultarPerfilesResponse>>
{
    private readonly IGestionPerfiles _gestionPerfiles;

    public ConsultarPerfilesQueryHandler(IGestionPerfiles gestionPerfiles) => _gestionPerfiles = gestionPerfiles;
    
    public async Task<DataViewModel<ConsultarPerfilesResponse>> Handle(ConsultarPerfilesQuery request, CancellationToken cancellationToken)
    {
        DataViewModel<ConsultarPerfilesResponse> res = await _gestionPerfiles.ConsultarPerfiles(request.Query);
        return res;
    }
}
